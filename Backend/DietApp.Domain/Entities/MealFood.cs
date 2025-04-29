using System;

namespace DietApp.Domain.Entities
{
    public class MealFood
    {
        public Guid Id { get; set; }
        public Guid MealId { get; set; }
        public Guid FoodId { get; set; }
        public double Quantity { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        // Navigation Properties
        public virtual Meal Meal { get; set; } = null!;
        public virtual Food Food { get; set; } = null!;
    }
} 