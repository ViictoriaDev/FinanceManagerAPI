using FinanceManager.Domain.Categorys;
using MediatR;
using System.Linq.Expressions;

namespace FinanceManager.Application.Categories.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<UpdateCategoryResponse> Handle(UpdateCategoryCommand query, CancellationToken ct)
        {
            var category = await _categoryRepository.GetByIdAsync(query.Id);

            if (category is null)
                throw new KeyNotFoundException("Categoria não encontrada.");

            category.Update(query.Name);

            await _categoryRepository.UpdateAsync(category);

            return new UpdateCategoryResponse(category.Id, category.Name);
        }
    }
}
