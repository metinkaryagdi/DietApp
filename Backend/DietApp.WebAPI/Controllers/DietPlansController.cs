using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Application.Features.DietPlans.Commands.CreateDietPlan;
using DietApp.Application.Features.DietPlans.Commands.DeleteDietPlan;
using DietApp.Application.Features.DietPlans.Commands.UpdateDietPlan;
using DietApp.Application.Features.DietPlans.Queries.GetDietPlanById;
using DietApp.Application.Features.DietPlans.Queries.GetDietPlansByUser;
using DietApp.Application.Features.DietPlans.Queries.GetActiveDietPlan;
using DietApp.Application.Features.DietPlans.Commands.ActivateDietPlan;
using DietApp.Application.Features.DietPlans.Commands.DeactivateDietPlan;
using DietApp.Application.Features.DietPlans.Queries.GetDietPlanProgress;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DietPlansController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DietPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetDietPlanByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetDietPlansByUserQuery { UserId = userId };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("active/{userId}")]
        public async Task<IActionResult> GetActive(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetActiveDietPlanQuery { UserId = userId };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("progress/{id}")]
        public async Task<IActionResult> GetProgress(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetDietPlanProgressQuery { DietPlanId = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDietPlanCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDietPlanCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteDietPlanCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost("{id}/activate")]
        public async Task<IActionResult> Activate(Guid id, CancellationToken cancellationToken)
        {
            var command = new ActivateDietPlanCommand { DietPlanId = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost("{id}/deactivate")]
        public async Task<IActionResult> Deactivate(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeactivateDietPlanCommand { DietPlanId = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
}
