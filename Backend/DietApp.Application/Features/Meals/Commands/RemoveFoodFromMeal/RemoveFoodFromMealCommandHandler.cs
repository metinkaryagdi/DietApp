using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Meals.Commands.RemoveFoodFromMeal
{
    public class RemoveFoodFromMealCommandHandler : IRequestHandler<RemoveFoodFromMealCommand, Unit>
    {
        private readonly IMealRepository _mealRepository;

        public RemoveFoodFromMealCommandHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<Unit> Handle(RemoveFoodFromMealCommand request, CancellationToken cancellationToken)
        {
            var mealFood = await _mealRepository.GetMealFoodAsync(request.MealId, request.FoodId, cancellationToken);
            if (mealFood == null)
            {
                throw new Exception($"Öğün ID: {request.MealId} ve Yiyecek ID: {request.FoodId} olan öğün-yiyecek ilişkisi bulunamadı.");
            }

            await _mealRepository.RemoveFoodFromMealAsync(mealFood, cancellationToken);
            await _mealRepository.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
} 