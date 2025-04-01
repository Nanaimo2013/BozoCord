using System;
using System.Collections.Generic;

namespace BozoCord.Core.Models.Server
{
    public class ServerMember
    {
        public string Id { get; set; }
        public string ServerId { get; set; }
        public string UserId { get; set; }
        public string Nickname { get; set; }
        public List<string> RoleIds { get; set; }
        public DateTime JoinedAt { get; set; }
        public DateTime? LastSeenAt { get; set; }
    }
} 