using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Commands.UpdateDietPlan
{
    public class UpdateDietPlanCommand : IRequest<DietPlan>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TargetCalories { get; set; }
        public decimal TargetProtein { get; set; }
        public decimal TargetCarbohydrate { get; set; }
        public decimal TargetFat { get; set; }
    }
} 