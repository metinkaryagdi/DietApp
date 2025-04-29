using DietApp.Domain.Interfaces;
using MediatR;

namespace DietApp.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, DeleteUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return new DeleteUserResponse
                {
                    Success = false,
                    Message = "User not found."
                };
            }

            await _userRepository.DeleteAsync(user);

            return new DeleteUserResponse
            {
                Success = true,
                Message = "User deleted successfully."
            };
        }
    }
}
