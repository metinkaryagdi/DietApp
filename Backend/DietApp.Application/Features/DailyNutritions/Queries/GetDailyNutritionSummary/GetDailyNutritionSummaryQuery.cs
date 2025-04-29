using System;
using MediatR;

namespace DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionSummary
{
    public class GetDailyNutritionSummaryQuery : IRequest<NutritionSummary>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class NutritionSummary
    {
        public decimal TotalCalories { get; set; }
        public decimal TotalProtein { get; set; }
        public decimal TotalCarbohydrate { get; set; }
        public decimal TotalFat { get; set; }
        public int DaysCount { get; set; }
        public decimal AverageCalories { get; set; }
        public decimal AverageProtein { get; set; }
        public decimal AverageCarbohydrate { get; set; }
        public decimal AverageFat { get; set; }
    }
} 