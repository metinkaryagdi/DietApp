using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Application.Features.Foods.Commands.CreateFood;
using DietApp.Application.Features.Foods.Commands.DeleteFood;
using DietApp.Application.Features.Foods.Commands.UpdateFood;
using DietApp.Application.Features.Foods.Queries.GetFoodById;
using DietApp.Application.Features.Foods.Queries.GetAllFoods;
using DietApp.Application.Features.Foods.Queries.SearchFoods;
using DietApp.Application.Features.Foods.Queries.GetFoodsByCategory;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class FoodsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var query = new GetAllFoodsQuery();
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetFoodByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string searchTerm, CancellationToken cancellationToken)
        {
            var query = new SearchFoodsQuery { SearchTerm = searchTerm };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetByCategory(string category, CancellationToken cancellationToken)
        {
            var query = new GetFoodsByCategoryQuery { Category = category };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateFoodCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateFoodCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteFoodCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }
    }
} 