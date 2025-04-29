using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Queries.GetDietPlanById
{
    public class GetDietPlanByIdQuery : IRequest<DietPlan>
    {
        public Guid Id { get; set; }
    }
} 