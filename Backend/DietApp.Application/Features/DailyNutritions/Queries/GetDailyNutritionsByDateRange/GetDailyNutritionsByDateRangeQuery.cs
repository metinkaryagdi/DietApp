using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionsByDateRange
{
    public class GetDailyNutritionsByDateRangeQuery : IRequest<IEnumerable<DailyNutrition>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
} 