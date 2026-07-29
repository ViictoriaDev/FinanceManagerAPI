using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Categorys;
using FinanceManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Category?> GetByIdAsync(Guid id)
            => await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Category?> GetByNameAndUserIdAsync(string name, Guid userId)
            => await _context.Categories.FirstOrDefaultAsync(c => c.Name == name && c.UserId == userId);

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<IEnumerable<Category>> GetByUserIdAsync(Guid userId)
            => await _context.Categories
            .Where(c => c.UserId == userId)
            .ToListAsync();

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var category = await GetByIdAsync(id);

            if (category is not null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

    }
}
