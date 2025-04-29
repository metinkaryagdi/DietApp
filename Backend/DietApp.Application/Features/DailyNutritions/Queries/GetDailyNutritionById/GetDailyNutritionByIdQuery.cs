using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionById
{
    public class GetDailyNutritionByIdQuery : IRequest<DailyNutrition>
    {
        public Guid Id { get; set; }
    }
} 