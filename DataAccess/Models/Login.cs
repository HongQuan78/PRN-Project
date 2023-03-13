using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Login
    {
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PasswordSalt { get; set; } = null!;
        public string? GoogleId { get; set; }
        public bool IsBanned { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
