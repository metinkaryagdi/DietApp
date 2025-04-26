using DietApp.Domain.Interfaces;
using MediatR;

namespace DietApp.Application.Features.DietPlans.Queries.GetAllDietPlans
{
    public class GetAllDietPlansHandler : IRequestHandler<GetAllDietPlansQuery, List<GetAllDietPlansResponse>>
    {
        private readonly IDietPlanRepository _dietPlanRepository;

        public GetAllDietPlansHandler(IDietPlanRepository dietPlanRepository)
        {
            _dietPlanRepository = dietPlanRepository;
        }

        public async Task<List<GetAllDietPlansResponse>> Handle(GetAllDietPlansQuery request, CancellationToken cancellationToken)
        {
            var dietPlans = await _dietPlanRepository.GetAllAsync();
            return dietPlans.Select(d => new GetAllDietPlansResponse
            {
                Id = d.Id,
                Name = d.Name,
                Meals = d.Meals
            }).ToList();
        }
    }
}
