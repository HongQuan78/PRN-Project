using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class MealLogItem
    {
        public string MealLogId { get; set; } = null!;
        public string ItemId { get; set; } = null!;
        public string ItemName { get; set; } = null!;
        public double ServingWeight { get; set; }
        public double ProteinPerServing { get; set; }
        public double FatPerServing { get; set; }
        public double CarbPerServing { get; set; }
        public double CaloriePerServing { get; set; }
        public double ActualWeight { get; set; }

        public virtual MealLog MealLog { get; set; } = null!;
    }
}
