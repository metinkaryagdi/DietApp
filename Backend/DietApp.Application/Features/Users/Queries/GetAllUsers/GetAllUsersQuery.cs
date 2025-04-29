using MediatR;
using DietApp.Application.Features.Users.Queries.GetAllUsers;

namespace DietApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetAllUsersResponse>>
    {
    }
}
