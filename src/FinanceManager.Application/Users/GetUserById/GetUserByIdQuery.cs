using MediatR;

namespace FinanceManager.Application.Users.GetUserById
{
    public record GetUserByIdQuery(Guid Id) : IRequest<GetUserByIdResponse>;
}
