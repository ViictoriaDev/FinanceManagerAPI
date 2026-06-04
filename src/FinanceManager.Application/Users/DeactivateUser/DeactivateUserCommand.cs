using MediatR;

namespace FinanceManager.Application.Users.DeactivateUser
{
    public record DeactivateUserCommand(Guid Id) : IRequest<DeactivateUserResponse>;
}
