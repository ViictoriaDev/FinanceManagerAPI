using FinanceManager.Application.Transactions.CreateTransaction;
using FinanceManager.Domain.Transactions;
using MediatR;

namespace FinanceManager.Application.Transactions.GetTransactionById
{
    public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, GetTransactionByIdResponse>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByIdHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<GetTransactionByIdResponse> Handle(GetTransactionByIdQuery query, CancellationToken ct)
        {
            var transaction = await _transactionRepository.GetByIdAsync(query.Id);

            if (transaction is null)
                throw new KeyNotFoundException("Transação não encontrada.");

            var transactionDto = new TransactionDto(
                transaction.Id,
                transaction.Description,
                transaction.Amount,
                transaction.Type,
                transaction.Date,
                transaction.AccountId,
                transaction.CategoryId,
                transaction.PaymentMethod);

            return new GetTransactionByIdResponse(transactionDto);
        }
    }
}
