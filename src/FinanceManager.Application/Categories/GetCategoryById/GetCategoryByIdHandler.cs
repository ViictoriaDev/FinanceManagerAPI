using FinanceManager.Domain.Categorys;
using MediatR;

namespace FinanceManager.Application.Categories.GetCategoryById
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, GetCategoryByIdResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdQuery query, CancellationToken ct)
        {
            var category = await _categoryRepository.GetByIdAsync(query.Id);

            if (category is null)
                throw new KeyNotFoundException("Categoria não encontrada");

            return new GetCategoryByIdResponse(category.Id, category.Name);
        }
    }
}
