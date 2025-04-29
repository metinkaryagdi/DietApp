using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Interfaces;
using DietApp.Application.Features.Meals.Dtos;

namespace DietApp.Application.Features.Meals.Queries.GetMealNutritionInfo
{
    public class GetMealNutritionInfoQueryHandler : IRequestHandler<GetMealNutritionInfoQuery, MealNutritionInfoDto>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealNutritionInfoQueryHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<MealNutritionInfoDto> Handle(GetMealNutritionInfoQuery request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetByIdAsync(request.MealId, cancellationToken);
            if (meal == null)
            {
                throw new Exception($"ID: {request.MealId} olan öğün bulunamadı.");
            }

            var nutritionInfo = await _mealRepository.GetMealNutritionInfoAsync(request.MealId, cancellationToken);

            return new MealNutritionInfoDto
            {
                MealId = meal.Id,
                MealName = meal.Name,
                TotalCalories = nutritionInfo.TotalCalories,
                TotalProtein = nutritionInfo.TotalProtein,
                TotalCarbohydrate = nutritionInfo.TotalCarbohydrate,
                TotalFat = nutritionInfo.TotalFat,
                Foods = nutritionInfo.Foods
            };
        }
    }
} 