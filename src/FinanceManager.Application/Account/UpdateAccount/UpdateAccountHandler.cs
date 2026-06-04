using FinanceManager.Domain.Accounts;
using MediatR;

namespace FinanceManager.Application.Account.UpdateAccount
{
    public class UpdateAccountHandler : IRequestHandler<UpdateAccountCommand, UpdateAccountResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public UpdateAccountHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<UpdateAccountResponse> Handle(UpdateAccountCommand request, CancellationToken ct)
        {
            var account = await _accountRepository.GetByIdAsync(request.Id);

            if (account is null)
                throw new KeyNotFoundException("Conta não encontrada.");

            account.Update(request.Name);

            await _accountRepository.UpdateAsync(account);

            return new UpdateAccountResponse(account.Id, account.Name);
        }
    }
}
