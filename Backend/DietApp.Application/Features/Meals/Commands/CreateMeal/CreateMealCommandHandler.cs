using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Meals.Commands.CreateMeal
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand, Meal>
    {
        private readonly IMealRepository _mealRepository;

        public CreateMealCommandHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<Meal> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = new Meal
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Date = request.Date,
                UserId = request.UserId,
                DietPlanId = request.DietPlanId
            };

            await _mealRepository.AddAsync(meal, cancellationToken);
            await _mealRepository.SaveChangesAsync(cancellationToken);

            return meal;
        }
    }
} 