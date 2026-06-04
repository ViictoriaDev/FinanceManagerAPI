using FinanceManager.Domain.Accounts;
using MediatR;

namespace FinanceManager.Application.Account.DeactivateAccount
{
    public class DeactivateAccountHandler : IRequestHandler<DeactivateAccountCommand, DeactivateAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public DeactivateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<DeactivateAccountResponse> Handle(DeactivateAccountCommand request, CancellationToken ct) 
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account is null) 
                throw new KeyNotFoundException("Conta não encontrada.");

            account.DeActivate();

            await _accountRepository.UpdateAsync(account); 

            return new DeactivateAccountResponse(account.Id, account.IsActive); 
        }
    }
}
