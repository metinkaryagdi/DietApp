using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Queries.GetMealsByUser
{
    public class GetMealsByUserQuery : IRequest<IEnumerable<Meal>>
    {
        public Guid UserId { get; set; }
    }
} 