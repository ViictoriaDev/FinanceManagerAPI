using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Categorys;
using FinanceManager.Domain.Enums;
using FinanceManager.Domain.Transactions;
using FinanceManager.Domain.Users;
using MediatR;

namespace FinanceManager.Application.Transactions.CreateTransaction
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, CreateTransactionResponse>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;

        public CreateTransactionHandler(
            ITransactionRepository transactionRepository,
            IAccountRepository accountRepository,
            ICategoryRepository categoryRepository
            )
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionCommand request, CancellationToken ct)
        {
            var account = await _accountRepository.GetByIdAsync(request.AccountId);

            if (account is null)
                throw new KeyNotFoundException(
                    $"A AccountId: {request.AccountId} vinculada a transação não existe.");

            if (account.UserId != request.UserId)
                throw new UnauthorizedAccessException(
                    $"A conta: {request.AccountId} não pertence ao usuário: {request.UserId}");
            
            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);
            
            if (category is null)
                throw new KeyNotFoundException(
                    $"A CategoryId: {request.CategoryId} vinculada a transação não existe.");

            var transaction = new Transaction(
                request.Description,
                request.Amount,
                request.Type,
                request.Date,
                request.AccountId,
                request.CategoryId,
                request.PaymentMethod);

            if (request.Type == ETransactionType.Income)
            {
                account.AddBalance(transaction.Amount);
            }
            else
            {
                account.SubtractBalance(transaction.Amount);
            }

            await _transactionRepository.AddAsync(transaction);
            await _accountRepository.UpdateAsync(account);

            var transactionDto = new TransactionDto(
                transaction.Id, 
                transaction.Description,
                transaction.Amount,
                transaction.Type,
                transaction.Date,
                transaction.AccountId,
                transaction.CategoryId,
                transaction.PaymentMethod);

            return new CreateTransactionResponse(transactionDto);
        }
    }
}
