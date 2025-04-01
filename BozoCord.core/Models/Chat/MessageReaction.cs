using System;

namespace BozoCord.Core.Models.Chat
{
    public class MessageReaction
    {
        public string Id { get; set; }
        public string MessageId { get; set; }
        public string UserId { get; set; }
        public string Emoji { get; set; }
        public DateTime CreatedAt { get; set; }
    }
} 