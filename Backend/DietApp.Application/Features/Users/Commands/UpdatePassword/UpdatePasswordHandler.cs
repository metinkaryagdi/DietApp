using System;
using System.Threading;
using System.Threading.Tasks;
using DietApp.Domain.Entities;
using DietApp.Domain.Interfaces;
using DietApp.Application.Common.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DietApp.Application.Features.Users.Commands.UpdatePassword
{
    public class UpdatePasswordHandler : IRequestHandler<UpdatePasswordCommand, UpdatePasswordResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher<User> _passwordHasher;

        public UpdatePasswordHandler(IUserRepository userRepository, IPasswordHasher<User> passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<UpdatePasswordResponse> Handle(UpdatePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new UserNotFoundException(request.UserId);
            }

            // Verify current password
            var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.CurrentPassword);
            if (passwordVerificationResult == PasswordVerificationResult.Failed)
            {
                return new UpdatePasswordResponse
                {
                    Success = false,
                    Message = "Mevcut şifre yanlış."
                };
            }

            // Hash and set new password
            user.PasswordHash = _passwordHasher.HashPassword(user, request.NewPassword);
            user.ModifiedDate = DateTime.UtcNow;

            await _userRepository.UpdateAsync(user);

            return new UpdatePasswordResponse
            {
                Success = true,
                Message = "Şifre başarıyla güncellendi."
            };
        }
    }
} 