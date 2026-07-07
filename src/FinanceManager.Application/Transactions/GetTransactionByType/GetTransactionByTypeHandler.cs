using FinanceManager.Application.Transactions.CreateTransaction;
using FinanceManager.Domain.Transactions;
using MediatR;

namespace FinanceManager.Application.Transactions.GetTransactionByType
{
    public class GetTransactionByTypeHandler : IRequestHandler<GetTransactionByTypeQuery, GetTransactionByTypeResponse>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByTypeHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<GetTransactionByTypeResponse> Handle(GetTransactionByTypeQuery query, CancellationToken ct)
        {
            var transactions = await _transactionRepository.GetByTypeAsync(query.Type);

            var transactionsDto = transactions.Select(t => new TransactionDto(
                t.Id, t.Description, t.Amount, t.Type, t.Date, t.AccountId, t.CategoryId, t.PaymentMethod));

            return new GetTransactionByTypeResponse(transactionsDto);
        }
    }
}
