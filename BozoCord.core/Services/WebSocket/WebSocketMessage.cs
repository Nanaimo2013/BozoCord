using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace BozoCord.Core.Services.WebSocket
{
    public enum WebSocketMessageType
    {
        // Connection
        Connect,
        Disconnect,
        Heartbeat,
        
        // Chat
        ChatMessage,
        MessageEdit,
        MessageDelete,
        MessageReaction,
        
        // Server
        ServerJoin,
        ServerLeave,
        ServerUpdate,
        
        // Channel
        ChannelJoin,
        ChannelLeave,
        ChannelUpdate,
        
        // User
        UserStatus,
        UserTyping,
        UserPresence,
        
        // Direct Messages
        DirectMessage,
        DirectMessageRead,
        
        // Error
        Error
    }

    public class WebSocketMessage
    {
        public WebSocketMessageType Type { get; set; }
        public string ChannelId { get; set; }
        public string ServerId { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestId { get; set; }
        public Dictionary<string, string> Headers { get; set; }

        public static WebSocketMessage Create(WebSocketMessageType type, string content = null)
        {
            return new WebSocketMessage
            {
                Type = type,
                Content = content,
                Timestamp = DateTime.UtcNow
            };
        }

        public T GetPayload<T>()
        {
            if (string.IsNullOrEmpty(Content))
                return default;

            try
            {
                return JsonSerializer.Deserialize<T>(Content);
            }
            catch
            {
                return default;
            }
        }

        public WebSocketMessage SetPayload<T>(T payload)
        {
            Content = JsonConvert.SerializeObject(payload);
            return this;
        }

        public WebSocketMessage SetHeader(string key, string value)
        {
            Headers ??= new Dictionary<string, string>();
            Headers[key] = value;
            return this;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public static WebSocketMessage FromJson(string json)
        {
            return JsonSerializer.Deserialize<WebSocketMessage>(json);
        }
    }
} 