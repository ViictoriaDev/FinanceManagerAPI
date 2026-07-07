using FinanceManager.Application.Transactions.CreateTransaction;

namespace FinanceManager.Application.Transactions.GetTransactionByType
{
    public record GetTransactionByTypeResponse(IEnumerable<TransactionDto> Transactions);
}
