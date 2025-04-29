using System;
using MediatR;
using System.Collections.Generic;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Commands.CreateDietPlan
{
    public class CreateDietPlanCommand : IRequest<DietPlan>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TargetCalories { get; set; }
        public decimal TargetProtein { get; set; }
        public decimal TargetCarbohydrate { get; set; }
        public decimal TargetFat { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CreateMealDto> Meals { get; set; } = new List<CreateMealDto>();
    }

    public class CreateMealDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime MealTime { get; set; }
        public ICollection<CreateMealFoodDto> MealFoods { get; set; } = new List<CreateMealFoodDto>();

        public double TotalCalories => MealFoods.Sum(mf => mf.Quantity * mf.Food.Calories / mf.Food.QuantityPerUnit);
        public double TotalProtein => MealFoods.Sum(mf => mf.Quantity * mf.Food.Protein / mf.Food.QuantityPerUnit);
        public double TotalCarbohydrate => MealFoods.Sum(mf => mf.Quantity * mf.Food.Carbohydrate / mf.Food.QuantityPerUnit);
        public double TotalFat => MealFoods.Sum(mf => mf.Quantity * mf.Food.Fat / mf.Food.QuantityPerUnit);
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
