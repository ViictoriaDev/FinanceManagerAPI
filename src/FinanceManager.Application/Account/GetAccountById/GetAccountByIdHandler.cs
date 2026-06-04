using FinanceManager.Domain.Accounts;
using MediatR;

namespace FinanceManager.Application.Account.GetAccountById
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdQuery, GetAccountByIdResponse>
    {
        private readonly IAccountRepository _accountRepository;

        public GetAccountByIdHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdQuery query, CancellationToken ct)
        {
            var account = await _accountRepository.GetByIdAsync(query.Id);
             
            if (account is null)
                throw new KeyNotFoundException("Conta não encontrada.");

            return new GetAccountByIdResponse(account.Id, account.Name, account.UserId);
        }
    }
}
