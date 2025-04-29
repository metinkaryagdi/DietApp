using System;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Foods.Commands.CreateFood
{
    public class CreateFoodCommand : IRequest<Food>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Carbohydrate { get; set; }
        public double Fat { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
    }
} 