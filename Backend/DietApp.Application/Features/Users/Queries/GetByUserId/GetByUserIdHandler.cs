using DietApp.Domain.Interfaces;
using MediatR;

namespace DietApp.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                return null; // veya throw new NotFoundException("User not found");
            }

            return new GetUserByIdResponse
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                BirthDate = user.BirthDate,
                Height = user.Height,
                Weight = user.Weight,
                TargetWeight = user.TargetWeight,
                CreatedDate = user.CreatedDate,
                ModifiedDate = user.ModifiedDate,
                IsActive = user.IsActive
            };
        }
    }
}
