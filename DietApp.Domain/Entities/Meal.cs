using System;
using System.Collections.Generic;

namespace DietApp.Domain.Entities
{
    public class Meal
    {
        public Meal()
        {
            MealFoods = new HashSet<MealFood>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid DietPlanId { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime MealTime { get; set; }
        public double? TotalCalories { get; set; }
        public double? TotalProtein { get; set; }
        public double? TotalCarbohydrate { get; set; }
        public double? TotalFat { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Navigation Properties
        public virtual User User { get; set; } = null!;
        public virtual DietPlan DietPlan { get; set; } = null!;
        public virtual ICollection<MealFood> MealFoods { get; set; }
    }
} 