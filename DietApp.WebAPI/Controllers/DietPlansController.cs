using DietApp.Application.Features.DietPlans.Commands.CreateDietPlan;
using DietApp.Application.Features.DietPlans.Queries.GetAllDietPlans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DietPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DietPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDietPlanCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(new { id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDietPlansQuery());
            return Ok(result);
        }
    }
}
