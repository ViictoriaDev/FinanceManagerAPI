using MediatR;

namespace FinanceManager.Application.Categories.CreateCategory
{
    public record CreateCategoryCommand(string Name, Guid UserId) : IRequest<CreateCategoryResponse>;
}
