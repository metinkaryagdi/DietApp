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
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Fat { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public string Category { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation properties
        public virtual ICollection<MealFood> MealFoods { get; set; }
    }
} 