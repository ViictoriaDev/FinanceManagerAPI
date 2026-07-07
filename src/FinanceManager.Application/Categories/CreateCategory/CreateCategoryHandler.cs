using FinanceManager.Domain.Categorys;
using MediatR;

namespace FinanceManager.Application.Categories.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryResponse>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<CreateCategoryResponse> Handle(CreateCategoryCommand request, CancellationToken ct)
        {
            var existingCategory = await _categoryRepository.GetByNameAndUserId(request.Name, request.UserId); //procura no banco de dados na Category se ja tem uma Category registrada com o nome da request. Por isso usar o is not null, porque se 'category' nao for null é pq ja existe uma category exatamente com esse nome. meu raciocinio esta certo??

            if (existingCategory is not null)
            {
                throw new Exception("Essa categoria já existe.");
            }

            var category = new Category(request.Name, request.UserId);

            await _categoryRepository.AddAsync(category);

            return new CreateCategoryResponse(category.Id, category.Name, category.UserId);
        }
    }
}
