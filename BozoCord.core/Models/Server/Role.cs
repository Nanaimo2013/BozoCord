using System;
using System.Collections.Generic;

namespace BozoCord.Core.Models.Server
{
    [Flags]
    public enum Permission
    {
        None = 0,
        ViewChannels = 1 << 0,
        SendMessages = 1 << 1,
        ManageMessages = 1 << 2,
        ManageChannels = 1 << 3,
        ManageServer = 1 << 4,
        ManageRoles = 1 << 5,
        KickMembers = 1 << 6,
        BanMembers = 1 << 7,
        CreateInvites = 1 << 8,
        ManageInvites = 1 << 9,
        ManageEmojis = 1 << 10,
        ViewAuditLog = 1 << 11,
        Administrator = 1 << 12,
        All = ~None
    }

    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Color { get; set; } = "#000000";
        public bool IsHoisted { get; set; }
        public int Position { get; set; }
        public Permission Permissions { get; set; }
        public bool IsMentionable { get; set; }
        public Guid? ServerId { get; set; }
        public Server? Server { get; set; }
        public List<User> Users { get; set; } = new();
        public RoleSettings Settings { get; set; } = new();
    }

    public class RoleSettings
    {
        public bool IsDefault { get; set; }
        public bool IsModerator { get; set; }
        public bool IsAdmin { get; set; }
        public bool CanBeAssigned { get; set; } = true;
        public Dictionary<string, object> CustomData { get; set; } = new();
    }
} 