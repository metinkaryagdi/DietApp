using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Foods.Queries.GetFoodById
{
    public class GetFoodByIdQuery : IRequest<Food>
    {
        public Guid Id { get; set; }
    }
} 
