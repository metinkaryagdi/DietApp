using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Queries.GetMealsByDietPlan
{
    public class GetMealsByDietPlanQuery : IRequest<IEnumerable<Meal>>
    {
        public Guid DietPlanId { get; set; }
    }
} 