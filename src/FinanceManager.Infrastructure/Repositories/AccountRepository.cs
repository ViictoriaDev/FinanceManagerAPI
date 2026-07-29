using FinanceManager.Domain.Accounts;
using FinanceManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account?> GetByIdAsync(Guid id)
            => await _context.Accounts.FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Account?> GetByNameAndUserIdAsync(string name, Guid userId)
            => await _context.Accounts.FirstOrDefaultAsync(a => a.Name == name && a.UserId == userId );

        public async Task<IEnumerable<Account>> GetAllAsync()
            => await _context.Accounts.ToListAsync();

        public async Task<IEnumerable<Account>> GetByUserIdAsync(Guid userId)
            => await _context.Accounts
            .Where(a => a.UserId == userId)
            .ToListAsync(); 

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
             _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var account = await GetByIdAsync(id);

            if (account is not null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
