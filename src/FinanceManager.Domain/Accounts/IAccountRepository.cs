namespace FinanceManager.Domain.Accounts
{
    public interface IAccountRepository
    {
        Task<Account?> GetByIdAsync(Guid id);
        Task<Account?> GetByNameAndUserId(string Name, Guid UserId);
        Task<IEnumerable<Account>> GetAllAsync();
        Task<IEnumerable<Account>> GetByUserIdAsync(Guid userId);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(Guid id);
    }
}