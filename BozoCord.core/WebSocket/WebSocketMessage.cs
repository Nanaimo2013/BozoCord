using System;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json;

namespace BozoCord.Core.WebSocket
{
    public enum WebSocketMessageType
    {
        // Connection
        Connect,
        Disconnect,
        Heartbeat,
        
        // Chat
        Message,
        MessageEdit,
        MessageDelete,
        ReactionAdd,
        ReactionRemove,
        
        // Server
        ServerJoin,
        ServerLeave,
        ServerUpdate,
        MemberJoin,
        MemberLeave,
        MemberUpdate,
        
        // Channel
        ChannelCreate,
        ChannelUpdate,
        ChannelDelete,
        ChannelJoin,
        ChannelLeave,
        
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

        public void SetPayload<T>(T payload)
        {
            Content = JsonConvert.SerializeObject(payload);
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

    public static class WebSocketMessageTypes
    {
        public const string Message = "message";
        public const string MessageEdit = "message_edit";
        public const string MessageDelete = "message_delete";
        public const string ReactionAdd = "reaction_add";
        public const string ReactionRemove = "reaction_remove";
        public const string TypingStart = "typing_start";
        public const string TypingStop = "typing_stop";
        public const string UserStatus = "user_status";
        public const string SubscribeServer = "subscribe_server";
        public const string UnsubscribeServer = "unsubscribe_server";
        public const string SubscribeChannel = "subscribe_channel";
        public const string UnsubscribeChannel = "unsubscribe_channel";
        public const string MemberJoin = "member_join";
        public const string MemberLeave = "member_leave";
        public const string MemberUpdate = "member_update";
        public const string ChannelCreate = "channel_create";
        public const string ChannelUpdate = "channel_update";
        public const string ChannelDelete = "channel_delete";
    }
} 