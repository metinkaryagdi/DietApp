using System;
using MediatR;
using DietApp.Application.Features.Meals.Dtos;

namespace DietApp.Application.Features.Meals.Queries.GetMealNutritionInfo
{
    public class GetMealNutritionInfoQuery : IRequest<MealNutritionInfoDto>
    {
        public Guid MealId { get; set; }
    }
} 