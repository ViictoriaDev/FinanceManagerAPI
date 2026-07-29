using FinanceManager.Domain.Enums;
using FinanceManager.Domain.Transactions;
using FinanceManager.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetByIdAsync(Guid id)
            => await _context.Transactions.FirstOrDefaultAsync(t => t.Id == id);

        public async Task<IEnumerable<Transaction>> GetAllAsync()
            => await _context.Transactions.ToListAsync();

        public async Task<IEnumerable<Transaction>> GetByCategoryIdAsync(Guid categoryId)
            => await _context.Transactions
            .Where(t => t.CategoryId == categoryId)
            .ToListAsync();

        public async Task<IEnumerable<Transaction>> GetByTypeAsync(ETransactionType type)
            => await _context.Transactions
            .Where(t => t.Type == type)
            .ToListAsync();

        public async Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId)
            => await _context.Transactions
            .Where(t => t.AccountId == accountId)
            .ToListAsync();

        public async Task AddAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var transaction = await GetByIdAsync(id);

            if (transaction is not null)
            {
                _context.Transactions.Remove(transaction);
                await _context.SaveChangesAsync();
            } 
        }
    }
}
