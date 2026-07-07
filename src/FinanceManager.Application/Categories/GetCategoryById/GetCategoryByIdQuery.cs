using MediatR;

namespace FinanceManager.Application.Categories.GetCategoryById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<GetCategoryByIdResponse>;
}
