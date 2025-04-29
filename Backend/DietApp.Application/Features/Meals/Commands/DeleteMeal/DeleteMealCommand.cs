using System;
using MediatR;

namespace DietApp.Application.Features.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommand : IRequest
    {
        public Guid Id { get; set; }
    }
} 