using System;
using MediatR;

namespace DietApp.Application.Features.DietPlans.Commands.DeleteDietPlan
{
    public class DeleteDietPlanCommand : IRequest
    {
        public Guid Id { get; set; }
    }
} 