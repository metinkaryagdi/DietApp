using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Queries.GetMealsByDate
{
    public class GetMealsByDateQuery : IRequest<IEnumerable<Meal>>
    {
        public DateTime Date { get; set; }
    }
} 