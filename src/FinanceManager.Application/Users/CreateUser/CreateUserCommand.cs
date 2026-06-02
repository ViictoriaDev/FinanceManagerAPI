using MediatR;

namespace FinanceManager.Application.Users.CreateUser
{
    public record CreateUserCommand(
        string Name,
        string Email,
        string Password
    ) : IRequest<CreateUserResponse>;
}
