using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DailyNutritions.Commands.UpdateDailyNutrition
{
    public class UpdateDailyNutritionCommand : IRequest<DailyNutrition>
    {
        public Guid Id { get; set; }
        public decimal TotalCalories { get; set; }
        public decimal TotalProtein { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal TotalFat { get; set; }
        public string Notes { get; set; }
    }
} 