using FinanceManager.Domain.Categorys;
using MediatR;

namespace FinanceManager.Application.Categories.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryCommand request, CancellationToken ct)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                throw new KeyNotFoundException("Categoria não encontrada");

            await _categoryRepository.DeleteAsync(request.Id);

            return new DeleteCategoryResponse(request.Id);
        } 
    }
}
