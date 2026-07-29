using FinanceManager.Domain.Categorys;
using MediatR;

namespace FinanceManager.Application.Categories.GetCategoriesByUserId
{
    public class GetCategoriesByUserIdHandler : IRequestHandler<GetCategoriesByUserIdQuery, GetCategoriesByUserIdResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesByUserIdHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<GetCategoriesByUserIdResponse> Handle(GetCategoriesByUserIdQuery query, CancellationToken ct)
        {
            var categories = await _categoryRepository.GetByUserIdAsync(query.UserId);

            var categoriesDto = categories.Select(c => new CategoriesByUserIdDto(c.Id, c.Name, c.UserId));

            return new GetCategoriesByUserIdResponse(categoriesDto);
        }
    }
}
