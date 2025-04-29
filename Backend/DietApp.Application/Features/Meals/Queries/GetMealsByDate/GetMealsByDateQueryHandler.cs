using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Meals.Queries.GetMealsByDate
{
    public class GetMealsByDateQueryHandler : IRequestHandler<GetMealsByDateQuery, IEnumerable<Meal>>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsByDateQueryHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<IEnumerable<Meal>> Handle(GetMealsByDateQuery request, CancellationToken cancellationToken)
        {
            return await _mealRepository.GetByDateAsync(request.Date, cancellationToken);
        }
    }
} 