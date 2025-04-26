using MediatR;
using System.Collections.Generic;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Commands.CreateDietPlan
{
    public class CreateDietPlanCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<CreateMealDto> Meals { get; set; } = new List<CreateMealDto>();
    }

    public class CreateMealDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime MealTime { get; set; }
        public double TotalCalories { get; set; }
        public double TotalProtein { get; set; }
        public double TotalCarbohydrate { get; set; }
        public double TotalFat { get; set; }
        public ICollection<CreateMealFoodDto> MealFoods { get; set; } = new List<CreateMealFoodDto>();
    }

    public class CreateMealFoodDto
    {
        public double Quantity { get; set; }
        public CreateFoodDto Food { get; set; } = new CreateFoodDto();
    }

    public class CreateFoodDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public string Unit { get; set; } = string.Empty;
        public double QuantityPerUnit { get; set; }
    }
}
