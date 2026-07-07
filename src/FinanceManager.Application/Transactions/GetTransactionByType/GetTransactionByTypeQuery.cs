using FinanceManager.Domain.Enums;
using MediatR;

namespace FinanceManager.Application.Transactions.GetTransactionByType
{
    public record GetTransactionByTypeQuery(ETransactionType Type) : IRequest<GetTransactionByTypeResponse>;
}