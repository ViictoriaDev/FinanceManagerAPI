namespace FinanceManager.Domain.Categorys
{
    public interface ICategoryRepository
    {
        Task<Category?> GetByIdAsync(Guid id);
        Task<Category?> GetByNameAndUserId(string Name, Guid UserId);
        Task<IEnumerable<Category>> GetAllAsync();
        Task<IEnumerable<Category>> GetByUserId(Guid id);
        Task AddAsync(Category category);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }
}
