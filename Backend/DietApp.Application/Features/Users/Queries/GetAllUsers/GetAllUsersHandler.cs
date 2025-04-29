using DietApp.Domain.Interfaces;
using MediatR;

namespace DietApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllDietPlansHandler : IRequestHandler<GetAllUsersQuery, List<GetAllUsersResponse>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllDietPlansHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetAllUsersResponse>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(d => new GetAllUsersResponse
            {
                Id = d.Id, // <-- Id'yi de ekledik
                FirstName = d.FirstName,
                LastName = d.LastName,
                BirthDate = d.BirthDate,
                Height = d.Height,
                Weight = d.Weight,
                TargetWeight = d.TargetWeight,
                CreatedDate = d.CreatedDate,
                ModifiedDate = d.ModifiedDate,
                IsActive = d.IsActive
            }).ToList();
        }

    }
}
