using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Queries.GetDietPlansByUser
{
    public class GetDietPlansByUserQuery : IRequest<IEnumerable<DietPlan>>
    {
        public Guid UserId { get; set; }
    }
} 