using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Queries.GetActiveDietPlan
{
    public class GetActiveDietPlanQuery : IRequest<DietPlan>
    {
        public Guid UserId { get; set; }
    }
} 