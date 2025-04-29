using System;
using MediatR;

namespace DietApp.Application.Features.Meals.Commands.RemoveFoodFromMeal
{
    public class RemoveFoodFromMealCommand : IRequest<Unit>
    {
        public Guid MealId { get; set; }
        public Guid FoodId { get; set; }
    }
} 