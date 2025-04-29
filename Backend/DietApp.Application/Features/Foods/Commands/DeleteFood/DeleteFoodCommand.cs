using System;
using MediatR;

namespace DietApp.Application.Features.Foods.Commands.DeleteFood
{
    public class DeleteFoodCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}