using System;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Application.Features.Users.Commands.CreateUser;
using DietApp.Application.Features.Users.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DietApp.Persistence.Context;
using System.Linq;
using DietApp.Domain.Entities;

namespace DietApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ApplicationDbContext _context;

        public UsersController(IMediator mediator, ApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserCommand command, CancellationToken cancellationToken)
        {
            var userId = await _mediator.Send(command, cancellationToken);
            return Ok(userId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUsersQuery(), cancellationToken);
            return Ok(users);
        }
    }
} 