using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Foods.Commands.UpdateFood
{
    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, Food>
    {
        private readonly IFoodRepository _foodRepository;

        public UpdateFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Food> Handle(UpdateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = await _foodRepository.GetByIdAsync(request.Id);
            if (food == null)
            {
                throw new Exception("Yiyecek bulunamadı.");
            }

            food.Name = request.Name;
            food.Description = request.Description;
            food.Calories = (decimal)request.Calories;
            food.Protein = (decimal)request.Protein;
            food.Carbohydrate = (decimal)request.Carbohydrate;
            food.Fat = (decimal)request.Fat;
            food.Unit = request.Unit;
            food.Quantity = (decimal)request.Quantity;
            food.UpdatedDate = DateTime.Now;

            await _foodRepository.UpdateAsync(food);
            return food;
        }
    }
} 