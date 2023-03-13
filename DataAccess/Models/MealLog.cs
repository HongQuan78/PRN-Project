using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MealLog
    {
        public MealLog()
        {
            MealLogItems = new HashSet<MealLogItem>();
        }

        public string UserId { get; set; } = null!;
        public string MealLogId { get; set; } = null!;
        public string MealLogName { get; set; } = null!;
        public TimeSpan LogTime { get; set; }
        public DateTime LogDate { get; set; }
        public string LogNote { get; set; } = null!;

        public virtual User User { get; set; } = null!;
        public virtual ICollection<MealLogItem> MealLogItems { get; set; }
    }
}
