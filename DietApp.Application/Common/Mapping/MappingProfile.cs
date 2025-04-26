using AutoMapper;
using DietApp.Domain.Entities;
using DietApp.Application.Features.DietPlans.Queries.GetAllDietPlans;

namespace DietApp.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DietPlan, GetAllDietPlansResponse>();
        }
    }
}
