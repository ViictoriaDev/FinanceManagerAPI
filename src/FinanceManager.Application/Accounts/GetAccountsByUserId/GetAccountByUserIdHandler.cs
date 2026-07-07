using FinanceManager.Domain.Accounts;
using MediatR;

namespace FinanceManager.Application.Account.GetAccountsByUserId
{
    public class GetAccountByUserIdHandler : IRequestHandler<GetAccountByUserIdQuery, GetAccountByUserIdResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByUserIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<GetAccountByUserIdResponse> Handle(GetAccountByUserIdQuery query, CancellationToken ct)
        {
            var accounts = await _accountRepository.GetByUserIdAsync(query.UserId);

            var accountsDto = accounts.Select(a => new AccountDto(a.Id, a.Name, a.UserId));
            
            if (accounts is null)
                throw new KeyNotFoundException("Conta não encontrada");

            return new GetAccountByUserIdResponse(accountsDto);
        }
    }
}
