using MediatR;

namespace FinanceManager.Application.Transactions.GetTransactionById
{
    public record GetTransactionByIdQuery(Guid Id) : IRequest<GetTransactionByIdResponse>;
}
