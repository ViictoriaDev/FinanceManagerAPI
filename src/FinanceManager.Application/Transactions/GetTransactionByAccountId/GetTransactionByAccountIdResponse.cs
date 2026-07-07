using FinanceManager.Application.Transactions.CreateTransaction;

namespace FinanceManager.Application.Transactions.GetTransactionByAccountId
{
    public record GetTransactionByAccountIdResponse(IEnumerable<TransactionDto> Transactions);
}

