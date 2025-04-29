using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Application.Features.DailyNutritions.Commands.CreateDailyNutrition;
using DietApp.Application.Features.DailyNutritions.Commands.DeleteDailyNutrition;
using DietApp.Application.Features.DailyNutritions.Commands.UpdateDailyNutrition;
using DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionById;
using DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionsByUser;
using DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionsByDateRange;
using DietApp.Application.Features.DailyNutritions.Queries.GetDailyNutritionSummary;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class DailyNutritionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DailyNutritionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetDailyNutritionByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetDailyNutritionsByUserQuery { UserId = userId };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("date-range")]
        public async Task<IActionResult> GetByDateRange(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            CancellationToken cancellationToken)
        {
            var query = new GetDailyNutritionsByDateRangeQuery 
            { 
                StartDate = startDate,
                EndDate = endDate
            };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSummary(
            [FromQuery] DateTime startDate,
            [FromQuery] DateTime endDate,
            CancellationToken cancellationToken)
        {
            var query = new GetDailyNutritionSummaryQuery
            {
                StartDate = startDate,
                EndDate = endDate
            };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDailyNutritionCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDailyNutritionCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteDailyNutritionCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
} 