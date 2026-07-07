using MediatR;

namespace FinanceManager.Application.Accounts.CreateAccount
{
    public record CreateAccountCommand(string Name, Guid UserId) : IRequest<CreateAccountResponse>;
}
