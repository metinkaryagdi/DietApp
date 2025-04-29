using System.Collections.Generic;
using DietApp.Domain.Entities;

namespace DietApp.Application.Features.DietPlans.Queries.GetAllDietPlans
{
    public class GetAllDietPlansResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    }
}
