using System;
using System.Collections.Generic;
using BozoCord.Core.Models.User;

namespace BozoCord.Core.Models.Server
{
    public class Server
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<Channel> Channels { get; set; } = new();
        public List<User> Members { get; set; } = new();
        public List<Role> Roles { get; set; } = new();
        public ServerSettings Settings { get; set; } = new();
    }

    public class ServerSettings
    {
        public bool RequireVerification { get; set; }
        public bool AllowModeration { get; set; }
        public bool AllowCustomEmojis { get; set; }
        public bool AllowFileUploads { get; set; }
        public int MaxFileSize { get; set; } = 50; // MB
        public string[] AllowedFileTypes { get; set; } = Array.Empty<string>();
    }
} 