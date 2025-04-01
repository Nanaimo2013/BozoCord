using System;
using System.Threading.Tasks;
using BozoCord.Core.Models;
using BozoCord.Core.Models.Chat;
using BozoCord.Core.Models.Server;

namespace BozoCord.Core.WebSocket
{
    public interface IWebSocketService
    {
        Task SendMessageToUserAsync(string userId, WebSocketMessage message);
        Task SendMessageToServerAsync(string serverId, WebSocketMessage message);
        Task SendMessageToChannelAsync(string channelId, WebSocketMessage message);
        Task BroadcastMessageAsync(WebSocketMessage message);
        Task NotifyUserStatusChangeAsync(string userId, string status);
        Task NotifyMessageCreatedAsync(string channelId, Message message);
        Task NotifyMessageUpdatedAsync(string channelId, Message message);
        Task NotifyMessageDeletedAsync(string channelId, string messageId);
        Task NotifyReactionAddedAsync(string channelId, string messageId, MessageReaction reaction);
        Task NotifyReactionRemovedAsync(string channelId, string messageId, string userId, string emoji);
        Task NotifyUserTypingAsync(string channelId, string userId, bool isTyping);
        Task NotifyServerMemberJoinedAsync(string serverId, ServerMember member);
        Task NotifyServerMemberLeftAsync(string serverId, string userId);
        Task NotifyServerMemberUpdatedAsync(string serverId, ServerMember member);
        Task NotifyChannelCreatedAsync(string serverId, Channel channel);
        Task NotifyChannelUpdatedAsync(string serverId, Channel channel);
        Task NotifyChannelDeletedAsync(string serverId, string channelId);
    }
} 