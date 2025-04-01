using System;
using System.Collections.Generic;

namespace BozoCord.Core.Models.Server
{
    public enum ChannelType
    {
        Text,
        Voice,
        Announcement,
        Forum,
        Stage,
        Category
    }

    public class Channel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ChannelType Type { get; set; }
        public Guid ServerId { get; set; }
        public Server Server { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public Channel? Category { get; set; }
        public int Position { get; set; }
        public bool IsPrivate { get; set; }
        public List<Message> Messages { get; set; } = new();
        public List<Role> AllowedRoles { get; set; } = new();
        public ChannelSettings Settings { get; set; } = new();
    }

    public class ChannelSettings
    {
        public bool IsNSFW { get; set; }
        public bool SlowMode { get; set; }
        public int SlowModeInterval { get; set; } // seconds
        public bool RequireModeration { get; set; }
        public bool AllowThreads { get; set; }
        public bool AllowReactions { get; set; }
    }
} 