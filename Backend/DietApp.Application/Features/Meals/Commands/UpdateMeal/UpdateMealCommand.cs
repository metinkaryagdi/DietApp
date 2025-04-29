using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommand : IRequest<Meal>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime MealTime { get; set; }
        public Guid UserId { get; set; }
        public Guid? DietPlanId { get; set; }
    }
} 