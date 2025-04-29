using System;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;

namespace DietApp.Domain.Services
{
    public interface INutritionCalculatorService
    {
        Task<(decimal calories, decimal protein, decimal carbs, decimal fat)> CalculateMealNutritionAsync(
            Guid mealId, 
            CancellationToken cancellationToken = default);

        Task<(decimal calories, decimal protein, decimal carbs, decimal fat)> CalculateDailyNutritionAsync(
            Guid userId, 
            DateTime date, 
            CancellationToken cancellationToken = default);

        Task<(decimal calories, decimal protein, decimal carbs, decimal fat)> CalculateDietPlanNutritionAsync(
            Guid dietPlanId, 
            CancellationToken cancellationToken = default);

        Task ValidateNutritionConsistencyAsync(
            Guid userId, 
            DateTime date, 
            CancellationToken cancellationToken = default);
    }
} 