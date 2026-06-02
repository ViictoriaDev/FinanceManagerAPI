using FinanceManager.Domain.Enums;

namespace FinanceManager.Domain.Transaction
{
    public class Transaction : Entity
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public TransactionType Type { get; private set; }
        public DateTime Date { get; private set; }
        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }

        public Transaction(
            string description,
            decimal amount,
            TransactionType type,
            DateTime date,
            Account accountId,
            Category categoryId)
        {
            if(amount <= 0)
                throw new ArgumentException("O valor da transação deve ser maior que zero.", nameof(amount));
            
            Description = description;
            Amount = amount;
            Type = type;
            Date = date;
            Account = accountId;
            Category = categoryId;
        }
    }
}
