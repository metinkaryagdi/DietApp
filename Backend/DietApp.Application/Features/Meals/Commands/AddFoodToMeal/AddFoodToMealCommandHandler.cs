using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Meals.Commands.AddFoodToMeal
{
    public class AddFoodToMealCommandHandler : IRequestHandler<AddFoodToMealCommand, MealFood>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IFoodRepository _foodRepository;

        public AddFoodToMealCommandHandler(IMealRepository mealRepository, IFoodRepository foodRepository)
        {
            _mealRepository = mealRepository;
            _foodRepository = foodRepository;
        }

        public async Task<MealFood> Handle(AddFoodToMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetByIdAsync(request.MealId, cancellationToken);
            if (meal == null)
            {
                throw new Exception($"ID: {request.MealId} olan öğün bulunamadı.");
            }

            var food = await _foodRepository.GetByIdAsync(request.FoodId, cancellationToken);
            if (food == null)
            {
                throw new Exception($"ID: {request.FoodId} olan yiyecek bulunamadı.");
            }

            var mealFood = new MealFood
            {
                Id = Guid.NewGuid(),
                MealId = request.MealId,
                FoodId = request.FoodId,
                Quantity = request.Quantity
            };

            await _mealRepository.AddFoodToMealAsync(mealFood, cancellationToken);
            await _mealRepository.SaveChangesAsync(cancellationToken);

            return mealFood;
        }
    }
} 