using FinanceManager.Domain.Enums;

namespace FinanceManager.Application.Transactions.CreateTransaction
{
    public record TransactionDto(Guid Id,
        string Description,
        decimal Amount,
        ETransactionType Type,
        DateTime Date,
        Guid AccountId,
        Guid CategoryId,
        EPaymentMethod PaymentMethod);
    public record CreateTransactionResponse(TransactionDto Transaction);
}
