using System;
using System.Collections.Generic;
using BozoCord.Core.Models.Server;
using BozoCord.Core.Models.Chat;

namespace BozoCord.Core.Models.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public string Status { get; set; } = "offline";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastSeen { get; set; } = DateTime.UtcNow;
        public bool IsEmailVerified { get; set; }
        public List<Server.Server> Servers { get; set; } = new();
        public List<DirectMessage> DirectMessages { get; set; } = new();
        public List<Role> Roles { get; set; } = new();
    }
}