using MediatR;

namespace FinanceManager.Application.Account.GetAccountsByUserId
{
    public record GetAccountByUserIdQuery(Guid UserId) : IRequest<GetAccountByUserIdResponse>;
}
