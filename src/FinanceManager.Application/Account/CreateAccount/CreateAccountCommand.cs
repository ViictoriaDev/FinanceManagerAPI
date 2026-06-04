using MediatR;

namespace FinanceManager.Application.Account.CreateAccount
{
    public record CreateAccountCommand(Guid Id, string Name, Guid UserId) : IRequest<CreateAccountResponse>;
}
