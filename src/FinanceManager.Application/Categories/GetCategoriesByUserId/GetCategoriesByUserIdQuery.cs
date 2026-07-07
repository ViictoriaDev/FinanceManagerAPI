using MediatR;

namespace FinanceManager.Application.Categories.GetCategoriesByUserId
{
    public record GetCategoriesByUserIdQuery(Guid UserId) : IRequest<GetCategoriesByUserIdResponse>;
}
