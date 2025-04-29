using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Foods.Commands.CreateFood
{
    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, Food>
    {
        private readonly IFoodRepository _foodRepository;

        public CreateFoodCommandHandler(IFoodRepository foodRepository)
        {
            _foodRepository = foodRepository;
        }

        public async Task<Food> Handle(CreateFoodCommand request, CancellationToken cancellationToken)
        {
            var food = new Food
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Calories = (decimal)request.Calories,
                Protein = (decimal)request.Protein,
                Carbohydrate = (decimal)request.Carbohydrate,
                Fat = (decimal)request.Fat,
                Unit = request.Unit,
                Quantity = (decimal)request.Quantity
            };

            await _foodRepository.AddAsync(food);
            await _foodRepository.SaveChangesAsync();

            return food;
        }
    }
} 