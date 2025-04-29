using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Meals.Queries.GetMealById
{
    public class GetMealByIdQuery : IRequest<Meal>
    {
        public Guid Id { get; set; }
    }
} 