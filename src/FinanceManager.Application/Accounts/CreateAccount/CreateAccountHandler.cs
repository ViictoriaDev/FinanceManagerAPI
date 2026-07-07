using FinanceManager.Application.Transactions.CreateTransaction;
using FinanceManager.Domain.Accounts;
using MediatR;

namespace FinanceManager.Application.Accounts.CreateAccount
{
    public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, CreateAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public CreateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<CreateAccountResponse> Handle(CreateAccountCommand request, CancellationToken ct)
        {
            var existingAccount = await _accountRepository.GetByNameAndUserId(request.Name, request.UserId);

            if (existingAccount is not null)
                throw new Exception("Essa conta já existe para esse usuário");

            var account = new Account(request.Name, request.UserId);

            await _accountRepository.AddAsync(account);

            return new CreateAccountResponse(account.Id, account.Name, account.UserId);
        }
    }
}
