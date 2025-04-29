using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Commands.CreateMeal
{
    public class CreateMealCommand : IRequest<Meal>
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Guid UserId { get; set; }
        public Guid? DietPlanId { get; set; }
    }
} 