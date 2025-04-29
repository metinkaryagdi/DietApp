using System;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;
using DietApp.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DietApp.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new UserAlreadyExistsException(request.Email);

            var user = new User
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserName = request.Email,
                BirthDate = request.BirthDate,
                Height = request.Height,
                Weight = request.Weight,
                TargetWeight = request.TargetWeight,
                CreatedDate = DateTime.UtcNow,
                IsActive = true
            };

            user.PasswordHash = _passwordHasher.HashPassword(user, request.Password);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
} 