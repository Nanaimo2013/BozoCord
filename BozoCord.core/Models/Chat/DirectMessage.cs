using System;
using System.Collections.Generic;
using BozoCord.Core.Models.User;

namespace BozoCord.Core.Models.Chat
{
    public class DirectMessage
    {
        public Guid Id { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; } = null!;
        public Guid RecipientId { get; set; }
        public User Recipient { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ReadAt { get; set; }
        public List<Attachment> Attachments { get; set; } = new();
        public List<Reaction> Reactions { get; set; } = new();
        public DirectMessageMetadata Metadata { get; set; } = new();
    }

    public class DirectMessageMetadata
    {
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSystemMessage { get; set; }
        public string? SystemMessageType { get; set; }
        public Dictionary<string, object> CustomData { get; set; } = new();
    }
} 