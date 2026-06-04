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
            var account = await _accountRepository.GetByUserIdAsync(query.UserId);

            if (account is null)
                throw new KeyNotFoundException("Conta não encontrada");

            return new GetAccountByUserIdResponse();
        }
    }
}
