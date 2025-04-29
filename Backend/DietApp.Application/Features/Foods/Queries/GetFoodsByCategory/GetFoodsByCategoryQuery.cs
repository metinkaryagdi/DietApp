using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Foods.Queries.GetFoodsByCategory
{
    public class GetFoodsByCategoryQuery : IRequest<IEnumerable<Food>>
    {
        public string Category { get; set; }
    }
} 