using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Foods.Queries.GetAllFoods
{
    public class GetAllFoodsQuery : IRequest<IEnumerable<Food>>
    {
    }
} 