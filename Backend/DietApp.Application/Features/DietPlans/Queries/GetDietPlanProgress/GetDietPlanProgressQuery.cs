using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Queries.GetDietPlanProgress
{
    public class GetDietPlanProgressQuery : IRequest<DietPlanProgress>
    {
        public Guid DietPlanId { get; set; }
    }

    public class DietPlanProgress
    {
        public Guid DietPlanId { get; set; }
        public string DietPlanName { get; set; }
        public decimal ActualCalories { get; set; }
        public decimal TargetCalories { get; set; }
        public decimal ActualProtein { get; set; }
        public decimal TargetProtein { get; set; }
        public decimal ActualCarbohydrate { get; set; }
        public decimal TargetCarbohydrate { get; set; }
        public decimal ActualFat { get; set; }
        public decimal TargetFat { get; set; }
        public decimal ProgressPercentage { get; set; }
    }
} 