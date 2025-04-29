using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Application.Features.Meals.Commands.CreateMeal;
using DietApp.Application.Features.Meals.Commands.DeleteMeal;
using DietApp.Application.Features.Meals.Commands.UpdateMeal;
using DietApp.Application.Features.Meals.Queries.GetMealById;
using DietApp.Application.Features.Meals.Queries.GetMealsByUser;
using DietApp.Application.Features.Meals.Queries.GetMealsByDate;
using DietApp.Application.Features.Meals.Queries.GetMealsByDietPlan;
using DietApp.Application.Features.Meals.Commands.AddFoodToMeal;
using DietApp.Application.Features.Meals.Commands.RemoveFoodFromMeal;
using DietApp.Application.Features.Meals.Queries.GetMealNutritionInfo;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DietApp.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class MealsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MealsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetMealByIdQuery { Id = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(Guid userId, CancellationToken cancellationToken)
        {
            var query = new GetMealsByUserQuery { UserId = userId };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetByDate(DateTime date, CancellationToken cancellationToken)
        {
            var query = new GetMealsByDateQuery { Date = date };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpGet("diet-plan/{dietPlanId}")]
        public async Task<IActionResult> GetByDietPlan(Guid dietPlanId, CancellationToken cancellationToken)
        {
            var query = new GetMealsByDietPlanQuery { DietPlanId = dietPlanId };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMealCommand command, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMealCommand command, CancellationToken cancellationToken)
        {
            command.Id = id;
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var command = new DeleteMealCommand { Id = id };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpPost("{mealId}/foods")]
        public async Task<IActionResult> AddFood(Guid mealId, [FromBody] AddFoodToMealCommand command, CancellationToken cancellationToken)
        {
            command.MealId = mealId;
            var result = await _mediator.Send(command, cancellationToken);
            return Ok(result);
        }

        [HttpDelete("{mealId}/foods/{foodId}")]
        public async Task<IActionResult> RemoveFood(Guid mealId, Guid foodId, CancellationToken cancellationToken)
        {
            var command = new RemoveFoodFromMealCommand { MealId = mealId, FoodId = foodId };
            await _mediator.Send(command, cancellationToken);
            return NoContent();
        }

        [HttpGet("{id}/nutrition")]
        public async Task<IActionResult> GetNutritionInfo(Guid id, CancellationToken cancellationToken)
        {
            var query = new GetMealNutritionInfoQuery { MealId = id };
            var result = await _mediator.Send(query, cancellationToken);
            return Ok(result);
        }
    }
} 