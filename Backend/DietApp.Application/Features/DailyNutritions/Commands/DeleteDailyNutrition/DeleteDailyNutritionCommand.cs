using System;
using MediatR;

namespace DietApp.Application.Features.DailyNutritions.Commands.DeleteDailyNutrition
{
    public class DeleteDailyNutritionCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
} 