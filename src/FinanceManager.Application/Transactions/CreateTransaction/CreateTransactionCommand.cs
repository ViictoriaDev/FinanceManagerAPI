using FinanceManager.Domain.Enums;
using MediatR;

namespace FinanceManager.Application.Transactions.CreateTransaction
{
    public record CreateTransactionCommand(
        Guid AccountId,
        Guid CategoryId,
        Guid UserId,
        string Description,
        decimal Amount,
        ETransactionType Type,
        DateTime Date,
        EPaymentMethod PaymentMethod
        ) : IRequest<CreateTransactionResponse>;
}
