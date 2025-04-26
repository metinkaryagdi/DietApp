using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace DietApp.Domain.Entities
{
    public class User : IdentityUser<Guid>
    {
        public User()
        {
            Meals = new HashSet<Meal>();
            DailyNutritions = new HashSet<DailyNutrition>();
        }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double TargetWeight { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsActive { get; set; }

        // Navigation Properties
        public virtual ICollection<Meal> Meals { get; set; }
        public virtual ICollection<DailyNutrition> DailyNutritions { get; set; }
    }
} 