using System;
using System.Collections.Generic;

namespace DietApp.Domain.Entities
{
    public class DietPlan
    {
        public DietPlan()
        {
            Meals = new HashSet<Meal>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public double? TotalCalories { get; set; }
        public double? TotalProtein { get; set; }
        public double? TotalCarbohydrate { get; set; }
        public double? TotalFat { get; set; }

        // Navigation Properties
        public virtual User User { get; set; } = null!;
        public virtual ICollection<Meal> Meals { get; set; }
    }
}
