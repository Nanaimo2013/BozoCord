using System;
using System.Collections.Generic;
using BozoCord.Core.Models.User;
using BozoCord.Core.Models.Server;

namespace BozoCord.Core.Models.Chat
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public Guid AuthorId { get; set; }
        public User Author { get; set; } = null!;
        public Guid ChannelId { get; set; }
        public Channel Channel { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? EditedAt { get; set; }
        public bool IsPinned { get; set; }
        public Guid? ReplyToMessageId { get; set; }
        public Message? ReplyToMessage { get; set; }
        public List<Attachment> Attachments { get; set; } = new();
        public List<Reaction> Reactions { get; set; } = new();
        public List<Message> ThreadMessages { get; set; } = new();
        public MessageMetadata Metadata { get; set; } = new();
    }

    public class Attachment
    {
        public Guid Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public long FileSize { get; set; }
        public Guid MessageId { get; set; }
        public Message Message { get; set; } = null!;
    }

    public class Reaction
    {
        public Guid Id { get; set; }
        public string Emoji { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid MessageId { get; set; }
        public Message Message { get; set; } = null!;
    }

    public class MessageMetadata
    {
        public bool IsEdited { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsSystemMessage { get; set; }
        public string? SystemMessageType { get; set; }
        public Dictionary<string, object> CustomData { get; set; } = new();
    }
} 