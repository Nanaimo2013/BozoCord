namespace BozoCord.Core.WebSocket
{
    public static class WebSocketMessageExtensions
    {
        public static WebSocketMessage WithUserId(this WebSocketMessage message, string userId)
        {
            message.UserId = userId;
            return message;
        }

        public static WebSocketMessage WithChannelId(this WebSocketMessage message, string channelId)
        {
            message.ChannelId = channelId;
            return message;
        }

        public static WebSocketMessage WithServerId(this WebSocketMessage message, string serverId)
        {
            message.ServerId = serverId;
            return message;
        }

        public static WebSocketMessage WithContent(this WebSocketMessage message, string content)
        {
            message.Content = content;
            return message;
        }
    }
} 