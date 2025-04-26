using System;

namespace DietApp.Domain.Entities
{
    public class DailyNutrition
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbohydrate { get; set; }
        public double TotalFat { get; set; }
        public double WaterIntake { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Navigation Properties
        public virtual User User { get; set; } = null!;
    }
} 