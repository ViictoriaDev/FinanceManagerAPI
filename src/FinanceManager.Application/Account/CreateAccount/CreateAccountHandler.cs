using FinanceManager.Domain.Accounts;
using MediatR;

namespace FinanceManager.Application.Account.CreateAccount
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
            var existingAccount = await _accountRepository.GetByIdAsync(request.Id);

            if (existingAccount is not null)
                throw new Exception("Essa conta já existe");

            var account = new Account(request.Id, request.Name, request.UserId);

            await _accountRepository.AddAsync(account);

            return new CreateAccountResponse(account.Id, account.Name, account.UserId);
        }
    }
}
