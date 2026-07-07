using MediatR;

namespace FinanceManager.Application.Transactions.GetTransactionByAccountId
{
    public record GetTransactionByAccountIdQuery(Guid AccountId)
        : IRequest<GetTransactionByAccountIdResponse>;
}
