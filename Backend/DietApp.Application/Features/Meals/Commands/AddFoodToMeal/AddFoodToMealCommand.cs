using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Commands.AddFoodToMeal
{
    public class AddFoodToMealCommand : IRequest<MealFood>
    {
        public Guid MealId { get; set; }
        public Guid FoodId { get; set; }
        public decimal Quantity { get; set; }
    }
} 