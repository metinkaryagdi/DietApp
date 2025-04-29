using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Meals.Queries.GetMealById
{
    public class GetMealByIdQueryHandler : IRequestHandler<GetMealByIdQuery, Meal>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealByIdQueryHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<Meal> Handle(GetMealByIdQuery request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetByIdAsync(request.Id, cancellationToken);
            if (meal == null)
            {
                throw new Exception($"ID: {request.Id} olan öğün bulunamadı.");
            }

            return meal;
        }
    }
} 