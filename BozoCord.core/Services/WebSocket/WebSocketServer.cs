using System;
using System.Collections.Generic;
using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using BozoCord.Core.Logger;
using BozoCord.Core.WebSocket;

namespace BozoCord.Core.Services.WebSocket
{
    public class WebSocketServer
    {
        private readonly HttpListener _listener;
        private readonly Dictionary<string, System.Net.WebSockets.WebSocket> _clients;
        private readonly Dictionary<string, HashSet<string>> _subscriptions;
        private readonly object _lock = new();
        private bool _isRunning;
        private readonly ILogger<WebSocketServer> _logger;
        private readonly ILogger<WebSocketClient> _clientLogger;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public WebSocketServer(string prefix, ILogger<WebSocketServer> logger, ILogger<WebSocketClient> clientLogger)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefix);
            _logger = logger;
            _clients = new();
            _subscriptions = new();
            _cancellationTokenSource = new();
        }

        public async Task StartAsync()
        {
            _listener.Start();
            _isRunning = true;
            _logger.LogInformation("WebSocket server started");

            while (_isRunning)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    if (context.Request.IsWebSocketRequest)
                    {
                        ProcessWebSocketRequest(context);
                    }
                    else
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error processing WebSocket request");
                }
            }
        }

        private async void ProcessWebSocketRequest(HttpListenerContext context)
        {
            var webSocketContext = await context.AcceptWebSocketAsync(null);
            var connection = new WebSocketConnection { WebSocket = webSocketContext.WebSocket, ConnectedAt = DateTime.UtcNow };
            
            lock (_lock)
            {
                _clients[connection.Id] = connection.WebSocket;
            }

            _logger.LogInformation("New WebSocket connection established: {ConnectionId}", connection.Id);

            try
            {
                await HandleConnectionAsync(connection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error handling WebSocket connection: {ConnectionId}", connection.Id);
            }
            finally
            {
                await CloseConnectionAsync(connection);
            }
        }

        private async Task HandleConnectionAsync(WebSocketConnection connection)
        {
            var buffer = new byte[4096];
            var messageBuilder = new StringBuilder();

            while (connection.WebSocket.State == WebSocketState.Open)
            {
                try
                {
                    var result = await connection.WebSocket.ReceiveAsync(
                        new ArraySegment<byte>(buffer), CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await connection.WebSocket.CloseAsync(
                            WebSocketCloseStatus.NormalClosure,
                            "Client requested close",
                            CancellationToken.None);
                        break;
                    }

                    messageBuilder.Append(Encoding.UTF8.GetString(buffer, 0, result.Count));

                    if (result.EndOfMessage)
                    {
                        var message = messageBuilder.ToString();
                        messageBuilder.Clear();

                        await ProcessMessageAsync(connection, message);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error receiving message from connection: {ConnectionId}", connection.Id);
                    break;
                }
            }
        }

        private async Task ProcessMessageAsync(WebSocketConnection connection, string message)
        {
            try
            {
                var wsMessage = WebSocketMessage.FromJson(message);
                if (wsMessage == null)
                {
                    await SendErrorAsync(connection, "Invalid message format");
                    return;
                }

                switch (wsMessage.Type)
                {
                    case WebSocketMessageType.Connect:
                        await HandleConnectAsync(connection, wsMessage);
                        break;

                    case WebSocketMessageType.Heartbeat:
                        await HandleHeartbeatAsync(connection);
                        break;

                    case WebSocketMessageType.Message:
                        await HandleChatMessageAsync(connection, wsMessage);
                        break;

                    case WebSocketMessageType.UserStatus:
                        await HandleUserStatusAsync(connection, wsMessage);
                        break;

                    // Add more message type handlers here
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message from connection: {ConnectionId}", connection.Id);
                await SendErrorAsync(connection, "Error processing message");
            }
        }

        private async Task HandleConnectAsync(WebSocketConnection connection, WebSocketMessage message)
        {
            var userId = message.GetPayload<string>();
            if (string.IsNullOrEmpty(userId))
            {
                await SendErrorAsync(connection, "Invalid user ID");
                return;
            }

            await SendMessageAsync(connection, WebSocketMessage.Create(WebSocketMessageType.Connect, "Connected successfully"));
        }

        private async Task HandleHeartbeatAsync(WebSocketConnection connection)
        {
            await SendMessageAsync(connection, WebSocketMessage.Create(WebSocketMessageType.Heartbeat, DateTime.UtcNow.ToString()));
        }

        private async Task HandleChatMessageAsync(WebSocketConnection connection, WebSocketMessage message)
        {
            if (string.IsNullOrEmpty(message.ChannelId))
            {
                await SendErrorAsync(connection, "Channel ID is required");
                return;
            }

            // Broadcast to all subscribers of the channel
            await BroadcastToChannelAsync(message.ChannelId, message);
        }

        private async Task HandleUserStatusAsync(WebSocketConnection connection, WebSocketMessage message)
        {
            var status = message.GetPayload<string>();
            if (string.IsNullOrEmpty(status))
            {
                await SendErrorAsync(connection, "Invalid status format");
                return;
            }

            // Broadcast to all connections in the same servers
            await BroadcastToUserServersAsync(connection.UserId, message);
        }

        private async Task BroadcastToChannelAsync(string channelId, WebSocketMessage message)
        {
            if (!_subscriptions.TryGetValue(channelId, out var subscribers))
                return;

            foreach (var subscriberId in subscribers)
            {
                if (_clients.TryGetValue(subscriberId, out var subscriber))
                {
                    await SendMessageAsync(subscriber, message);
                }
            }
        }

        private async Task BroadcastToUserServersAsync(string userId, WebSocketMessage message)
        {
            // Implement server-specific broadcasting logic
            // This would require maintaining a mapping of users to their servers
        }

        private async Task SendMessageAsync(WebSocketConnection connection, WebSocketMessage message)
        {
            try
            {
                var json = message.ToJson();
                var buffer = Encoding.UTF8.GetBytes(json);
                await connection.WebSocket.SendAsync(
                    new ArraySegment<byte>(buffer),
                    WebSocketMessageType.Text,
                    true,
                    CancellationToken.None);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending message to connection: {ConnectionId}", connection.Id);
            }
        }

        private async Task SendErrorAsync(WebSocketConnection connection, string error)
        {
            var errorMessage = WebSocketMessage.Create(WebSocketMessageType.Error, error);
            await SendMessageAsync(connection, errorMessage);
        }

        private async Task CloseConnectionAsync(WebSocketConnection connection)
        {
            lock (_lock)
            {
                _clients.Remove(connection.Id);
            }

            if (connection.WebSocket.State == WebSocketState.Open)
            {
                await connection.WebSocket.CloseAsync(
                    WebSocketCloseStatus.InternalServerError,
                    "Connection closed",
                    CancellationToken.None);
            }

            _logger.LogInformation("WebSocket connection closed: {ConnectionId}", connection.Id);
        }

        public void Stop()
        {
            _isRunning = false;
            _listener.Stop();
            _logger.LogInformation("WebSocket server stopped");
        }

        private class WebSocketConnection
        {
            public System.Net.WebSockets.WebSocket WebSocket { get; set; }
            public DateTime ConnectedAt { get; set; }
            public string? UserId { get; set; }
            public DateTime LastHeartbeat { get; set; } = DateTime.UtcNow;
            public string Id => Guid.NewGuid().ToString();
        }
    }
} 