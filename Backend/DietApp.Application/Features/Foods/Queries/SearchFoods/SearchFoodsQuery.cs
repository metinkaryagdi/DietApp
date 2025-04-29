using System;
using System.Collections.Generic;
using MediatR;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.Foods.Queries.SearchFoods
{
    public class SearchFoodsQuery : IRequest<IEnumerable<Food>>
    {
        public string SearchTerm { get; set; }
    }
} 