using System;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Interfaces;
using DietApp.Application.Common.Exceptions;
using MediatR;

namespace DietApp.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new UserNotFoundException(request.Id);
            }

            // Check if email is being changed and if it's already taken
            if (user.Email != request.Email)
            {
                var existingUser = await _userRepository.GetByEmailAsync(request.Email);
                if (existingUser != null)
                {
                    throw new UserAlreadyExistsException(request.Email);
                }
            }

            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.Email = request.Email;
            user.UserName = request.Email; // Keep UserName in sync with Email
            user.BirthDate = request.BirthDate;
            user.Height = request.Height;
            user.Weight = request.Weight;
            user.TargetWeight = request.TargetWeight;
            user.ModifiedDate = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            return new UpdateUserResponse
            {
                Success = true,
                Message = "User updated successfully."
            };
        }
    }
}
