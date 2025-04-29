using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DailyNutritions.Commands.CreateDailyNutrition
{
    public class CreateDailyNutritionCommand : IRequest<DailyNutrition>
    {
        public Guid UserId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalCalories { get; set; }
        public decimal TotalProtein { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal TotalFat { get; set; }
        public string Notes { get; set; }
    }
} 