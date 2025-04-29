using System;
using MediatR;

namespace DietApp.Application.Features.DietPlans.Commands.DeactivateDietPlan
{
    public class DeactivateDietPlanCommand : IRequest
    {
        public Guid DietPlanId { get; set; }
    }
} 