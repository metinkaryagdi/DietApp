using System;
using System.Collections.Generic;

namespace DietApp.Domain.Entities
{
    public class Food
    {
        public Food()
        {
            MealFoods = new HashSet<MealFood>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public string Unit { get; set; } = string.Empty;
        public double QuantityPerUnit { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<MealFood> MealFoods { get; set; }
    }
} 