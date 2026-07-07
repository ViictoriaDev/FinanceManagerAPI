using MediatR;

namespace FinanceManager.Application.Categories.DeleteCategory
{
    public record DeleteCategoryCommand(Guid Id) : IRequest<DeleteCategoryResponse>;
}
