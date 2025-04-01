using System;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BozoCord.Core.Logger;
using BozoCord.Core.WebSocket;

namespace BozoCord.Core.Services.WebSocket
{
    public class WebSocketClient : IDisposable
    {
        private readonly ClientWebSocket _webSocket;
        private readonly Uri _serverUri;
        private readonly ILogger _logger;
        private readonly CancellationTokenSource _cancellationTokenSource;
        private readonly Dictionary<string, TaskCompletionSource<WebSocketMessage>> _pendingRequests;
        private readonly Dictionary<WebSocketMessageType, Func<WebSocketMessage, Task>> _messageHandlers;
        private bool _isConnected;
        private string? _userId;

        public event EventHandler<WebSocketMessage>? MessageReceived;
        public event EventHandler? Connected;
        public event EventHandler? Disconnected;
        public event EventHandler<Exception>? Error;

        public WebSocketClient(Uri serverUri, ILogger logger)
        {
            _webSocket = new ClientWebSocket();
            _serverUri = serverUri;
            _logger = logger;
            _cancellationTokenSource = new CancellationTokenSource();
            _pendingRequests = new Dictionary<string, TaskCompletionSource<WebSocketMessage>>();
            _messageHandlers = new Dictionary<WebSocketMessageType, Func<WebSocketMessage, Task>>();

            RegisterDefaultHandlers();
        }

        private void RegisterDefaultHandlers()
        {
            _messageHandlers[WebSocketMessageType.Connect] = HandleConnectAsync;
            _messageHandlers[WebSocketMessageType.Heartbeat] = HandleHeartbeatAsync;
            _messageHandlers[WebSocketMessageType.Error] = HandleErrorAsync;
        }

        public async Task ConnectAsync(string userId)
        {
            try
            {
                await _webSocket.ConnectAsync(_serverUri, _cancellationTokenSource.Token);
                _isConnected = true;
                _userId = userId;

                // Send initial connect message
                var connectMessage = WebSocketMessage.Create(WebSocketMessageType.Connect, userId);
                await SendMessageAsync(connectMessage);

                // Start receiving messages
                _ = ReceiveMessagesAsync();
                _ = StartHeartbeatAsync();

                Connected?.Invoke(this, EventArgs.Empty);
                _logger.Information("WebSocket client connected successfully");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Failed to connect WebSocket client");
                Error?.Invoke(this, ex);
                throw;
            }
        }

        private async Task ReceiveMessagesAsync()
        {
            var buffer = new byte[4096];
            var messageBuilder = new StringBuilder();

            while (_isConnected && !_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    var result = await _webSocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer), _cancellationTokenSource.Token);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await DisconnectAsync();
                        break;
                    }

                    messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

                    if (result.EndOfMessage)
                    {
                        var message = messageBuilder.ToString();
                        messageBuilder.Clear();

                        await ProcessMessageAsync(message);
                    }
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error receiving WebSocket message");
                    Error?.Invoke(this, ex);
                }
            }
        }

        private async Task ProcessMessageAsync(string message)
        {
            try
            {
                var wsMessage = WebSocketMessage.FromJson(message);
                if (wsMessage == null)
                {
                    _logger.Warning("Received invalid message format");
                    return;
                }

                // Handle request-response pattern
                if (!string.IsNullOrEmpty(wsMessage.RequestId) && 
                    _pendingRequests.TryGetValue(wsMessage.RequestId, out var tcs))
                {
                    tcs.TrySetResult(wsMessage);
                    _pendingRequests.Remove(wsMessage.RequestId);
                    return;
                }

                // Handle message type specific handlers
                if (_messageHandlers.TryGetValue(wsMessage.Type, out var handler))
                {
                    await handler(wsMessage);
                }

                // Notify general message subscribers
                MessageReceived?.Invoke(this, wsMessage);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error processing WebSocket message");
                Error?.Invoke(this, ex);
            }
        }

        private async Task HandleConnectAsync(WebSocketMessage message)
        {
            _logger.Information("Connection confirmed by server");
        }

        private async Task HandleHeartbeatAsync(WebSocketMessage message)
        {
            // Server heartbeat received, no action needed
        }

        private async Task HandleErrorAsync(WebSocketMessage message)
        {
            var error = message.GetPayload<string>();
            _logger.Error("Server error: {Error}", error);
            Error?.Invoke(this, new Exception(error));
        }

        public async Task SendMessageAsync(WebSocketMessage message)
        {
            if (!_isConnected)
            {
                throw new InvalidOperationException("WebSocket is not connected");
            }

            try
            {
                var json = message.ToJson();
                var buffer = Encoding.UTF8.GetBytes(json);
                await _webSocket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    _cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error sending WebSocket message");
                Error?.Invoke(this, ex);
                throw;
            }
        }

        public async Task<WebSocketMessage> SendRequestAsync(WebSocketMessage message, TimeSpan timeout)
        {
            if (string.IsNullOrEmpty(message.RequestId))
            {
                message.RequestId = Guid.NewGuid().ToString();
            }

            var tcs = new TaskCompletionSource<WebSocketMessage>();
            _pendingRequests[message.RequestId] = tcs;

            try
            {
                await SendMessageAsync(message);
                using var cts = new CancellationTokenSource(timeout);
                return await tcs.Task.WaitAsync(cts.Token);
            }
            catch (TimeoutException)
            {
                _pendingRequests.Remove(message.RequestId);
                throw new TimeoutException($"Request {message.RequestId} timed out after {timeout.TotalSeconds} seconds");
            }
        }

        private async Task StartHeartbeatAsync()
        {
            while (_isConnected && !_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    var heartbeat = WebSocketMessage.Create(WebSocketMessageType.Heartbeat, DateTime.UtcNow.ToString());
                    await SendMessageAsync(heartbeat);
                    await Task.Delay(30000, _cancellationTokenSource.Token); // Send heartbeat every 30 seconds
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "Error sending heartbeat");
                    Error?.Invoke(this, ex);
                }
            }
        }

        public async Task DisconnectAsync()
        {
            if (!_isConnected)
                return;

            _isConnected = false;
            _cancellationTokenSource.Cancel();

            try
            {
                if (_webSocket.State == WebSocketState.Open)
                {
                    await _webSocket.CloseAsync(
                        WebSocketCloseStatus.NormalClosure,
                        "Client requested close",
                        CancellationToken.None);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error closing WebSocket connection");
                Error?.Invoke(this, ex);
            }
            finally
            {
                Disconnected?.Invoke(this, EventArgs.Empty);
                _logger.Information("WebSocket client disconnected");
            }
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _webSocket.Dispose();
        }
    }
} 