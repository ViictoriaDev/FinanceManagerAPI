using FinanceManager.Domain.Enums;

namespace FinanceManager.Domain.Transactions
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<Transaction?> GetByIdAsync(Guid id);
        Task<IEnumerable<Transaction>> GetAllAsync();
        Task<IEnumerable<Transaction>> GetByCategoryAsync(Guid categoryId);
        Task<IEnumerable<Transaction>> GetByTypeAsync(ETransactionType type);
        Task<IEnumerable<Transaction>> GetByAccountIdAsync(Guid accountId);
        Task UpdateAsync(Transaction transaction);
        Task DeleteAsync(Guid id);
    }
}
