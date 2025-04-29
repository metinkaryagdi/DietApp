using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;

namespace DietApp.Application.Features.Meals.Queries.GetMealsByDietPlan
{
    public class GetMealsByDietPlanQueryHandler : IRequestHandler<GetMealsByDietPlanQuery, IEnumerable<Meal>>
    {
        private readonly IMealRepository _mealRepository;

        public GetMealsByDietPlanQueryHandler(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public async Task<IEnumerable<Meal>> Handle(GetMealsByDietPlanQuery request, CancellationToken cancellationToken)
        {
            return await _mealRepository.GetByDietPlanIdAsync(request.DietPlanId, cancellationToken);
        }
    }
} 