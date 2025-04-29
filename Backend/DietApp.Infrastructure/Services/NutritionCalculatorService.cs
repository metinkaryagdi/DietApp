using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Interfaces;
using DietApp.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace DietApp.Infrastructure.Services
{
    public class NutritionCalculatorService : INutritionCalculatorService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IDailyNutritionRepository _dailyNutritionRepository;
        private readonly IDietPlanRepository _dietPlanRepository;

        public NutritionCalculatorService(
            IMealRepository mealRepository,
            IDailyNutritionRepository dailyNutritionRepository,
            IDietPlanRepository dietPlanRepository)
        {
            _mealRepository = mealRepository;
            _dailyNutritionRepository = dailyNutritionRepository;
            _dietPlanRepository = dietPlanRepository;
        }

        public async Task<(decimal calories, decimal protein, decimal carbs, decimal fat)> CalculateMealNutritionAsync(
            Guid mealId,
            CancellationToken cancellationToken = default)
        {
            var meal = await _mealRepository.GetByIdWithFoodsAsync(mealId, cancellationToken);
            if (meal == null)
                throw new Exception($"Meal with ID {mealId} not found.");

            var nutrition = meal.MealFoods.Aggregate(
                (calories: 0m, protein: 0m, carbs: 0m, fat: 0m),
                (total, mealFood) => (
                    calories: total.calories + (mealFood.Food.Calories * (decimal)mealFood.Quantity),
                    protein: total.protein + (mealFood.Food.Protein * (decimal)mealFood.Quantity),
                    carbs: total.carbs + (mealFood.Food.Carbohydrate * (decimal)mealFood.Quantity),
                    fat: total.fat + (mealFood.Food.Fat * (decimal)mealFood.Quantity)
                ));

            return nutrition;
        }

        public async Task<(decimal calories, decimal protein, decimal carbs, decimal fat)> CalculateDailyNutritionAsync(
            Guid userId,
            DateTime date,
            CancellationToken cancellationToken = default)
        {
            var meals = await _mealRepository.GetByUserAndDateAsync(userId, date, cancellationToken);
            
            var nutrition = (calories: 0m, protein: 0m, carbs: 0m, fat: 0m);
            foreach (var meal in meals)
            {
                var mealNutrition = await CalculateMealNutritionAsync(meal.Id, cancellationToken);
                nutrition.calories += mealNutrition.calories;
                nutrition.protein += mealNutrition.protein;
                nutrition.carbs += mealNutrition.carbs;
                nutrition.fat += mealNutrition.fat;
            }

            return nutrition;
        }

        public async Task<(decimal calories, decimal protein, decimal carbs, decimal fat)> CalculateDietPlanNutritionAsync(
            Guid dietPlanId,
            CancellationToken cancellationToken = default)
        {
            var dietPlan = await _dietPlanRepository.GetByIdAsync(dietPlanId, cancellationToken);
            if (dietPlan == null)
                throw new Exception($"Diet plan with ID {dietPlanId} not found.");

            var nutrition = (calories: 0m, protein: 0m, carbs: 0m, fat: 0m);
            foreach (var meal in dietPlan.Meals)
            {
                var mealNutrition = await CalculateMealNutritionAsync(meal.Id, cancellationToken);
                nutrition.calories += mealNutrition.calories;
                nutrition.protein += mealNutrition.protein;
                nutrition.carbs += mealNutrition.carbs;
                nutrition.fat += mealNutrition.fat;
            }

            return nutrition;
        }

        public async Task ValidateNutritionConsistencyAsync(
            Guid userId,
            DateTime date,
            CancellationToken cancellationToken = default)
        {
            var dailyNutrition = await _dailyNutritionRepository.GetByUserAndDateAsync(userId, date, cancellationToken);
            if (dailyNutrition == null)
                return;

            var calculatedNutrition = await CalculateDailyNutritionAsync(userId, date, cancellationToken);

            const decimal tolerance = 0.01m; // 1% tolerance for floating point calculations
            if (Math.Abs((decimal)dailyNutrition.TotalCalories - calculatedNutrition.calories) > tolerance ||
                Math.Abs((decimal)dailyNutrition.TotalProtein - calculatedNutrition.protein) > tolerance ||
                Math.Abs((decimal)dailyNutrition.TotalCarbohydrate - calculatedNutrition.carbs) > tolerance ||
                Math.Abs((decimal)dailyNutrition.TotalFat - calculatedNutrition.fat) > tolerance)
            {
                throw new Exception("Daily nutrition values are inconsistent with meal calculations.");
            }
        }
    }
} 