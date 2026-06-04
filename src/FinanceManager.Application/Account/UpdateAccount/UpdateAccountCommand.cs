using MediatR;

namespace FinanceManager.Application.Account.UpdateAccount
{
    public record UpdateAccountCommand(Guid Id, string Name) : IRequest<UpdateAccountResponse>;
}
