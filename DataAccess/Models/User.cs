using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class User
    {
        public User()
        {
            MealLogs = new HashSet<MealLog>();
        }

        public string UserId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public virtual Login? Login { get; set; }
        public virtual ICollection<MealLog> MealLogs { get; set; }
    }
}
