using MediatR;

namespace FinanceManager.Application.Categories.UpdateCategory
{
    public record UpdateCategoryCommand(Guid Id, string Name) : IRequest<UpdateCategoryResponse>;
}
