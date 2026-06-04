using MediatR;

namespace FinanceManager.Application.Account.DeactivateAccount
{
    public record DeactivateAccountCommand(Guid Id) : IRequest<DeactivateAccountResponse>;
}
