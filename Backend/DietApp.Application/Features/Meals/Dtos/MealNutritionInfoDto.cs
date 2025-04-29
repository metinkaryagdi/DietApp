using System;
using System.Collections.Generic;

namespace DietApp.Application.Features.Meals.Dtos
{
    public class MealNutritionInfoDto
    {
        public Guid MealId { get; set; }
        public string MealName { get; set; }
        public decimal TotalCalories { get; set; }
        public decimal TotalProtein { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal TotalFat { get; set; }
        public List<FoodNutritionDto> Foods { get; set; }
    }

    public class FoodNutritionDto
    {
        public Guid FoodId { get; set; }
        public string FoodName { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; }
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbohydrate { get; set; }
        public decimal Fat { get; set; }
    }
} 