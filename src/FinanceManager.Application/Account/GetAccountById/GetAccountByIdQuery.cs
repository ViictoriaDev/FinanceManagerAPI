using MediatR;

namespace FinanceManager.Application.Account.GetAccountById
{
    public record GetAccountByIdQuery(Guid Id) : IRequest<GetAccountByIdResponse>;
}
