using System;
using MediatR;

namespace DietApp.Application.Features.DietPlans.Commands.ActivateDietPlan
{
    public class ActivateDietPlanCommand : IRequest
    {
        public Guid DietPlanId { get; set; }
    }
} 