using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionsByUser
{
    public class GetDailyNutritionsByUserQuery : IRequest<IEnumerable<DailyNutrition>>
    {
        public Guid UserId { get; set; }
    }
} 