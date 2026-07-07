using FinanceManager.Application.Transactions.CreateTransaction;
using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Transactions;
using MediatR;

namespace FinanceManager.Application.Transactions.GetTransactionByAccountId
{
    public class GetTransactionByAccountIdHandler
        : IRequestHandler<GetTransactionByAccountIdQuery, GetTransactionByAccountIdResponse>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByAccountIdHandler(
            ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<GetTransactionByAccountIdResponse> Handle(GetTransactionByAccountIdQuery query, CancellationToken ct)
        {
            var transactions = await _transactionRepository.GetByAccountIdAsync(query.AccountId);

            var transactionsDto = transactions.Select(t => new TransactionDto(
                t.Id, t.Description, t.Amount, t.Type, t.Date, t.AccountId, t.CategoryId, t.PaymentMethod
                ));

            return new GetTransactionByAccountIdResponse(transactionsDto);
        }
    }
}
