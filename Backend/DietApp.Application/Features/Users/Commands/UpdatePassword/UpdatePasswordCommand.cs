using MediatR;

namespace DietApp.Application.Features.Users.Commands.UpdatePassword
{
    public class UpdatePasswordCommand : IRequest<UpdatePasswordResponse>
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }

    public class UpdatePasswordResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
} 