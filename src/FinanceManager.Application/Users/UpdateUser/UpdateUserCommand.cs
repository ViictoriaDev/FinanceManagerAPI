using MediatR;

namespace FinanceManager.Application.Users.UpdateUser
{
    public record UpdateUserCommand(Guid Id, string Name, string Email) : IRequest<UpdateUserResponse>;
}
