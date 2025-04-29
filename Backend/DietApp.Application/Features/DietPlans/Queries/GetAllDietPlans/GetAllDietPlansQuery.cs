using MediatR;
using DietApp.Application.Features.DietPlans.Queries.GetAllDietPlans;

namespace DietApp.Application.Features.DietPlans.Queries.GetAllDietPlans
{
    public class GetAllDietPlansQuery : IRequest<List<GetAllDietPlansResponse>>
    {
    }
}
