using MediatR;

namespace FinanceManager.Application.Users.GetAllUsers
{
    public record GetAllUsersQuery() : IRequest<GetAllUsersResponse>;
}
