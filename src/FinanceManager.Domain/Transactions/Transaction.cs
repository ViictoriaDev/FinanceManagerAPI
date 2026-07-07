using FinanceManager.Domain.Accounts;
using FinanceManager.Domain.Categorys;
using FinanceManager.Domain.Enums;

namespace FinanceManager.Domain.Transactions
{
    public class Transaction : Entity
    {
        public string Description { get; private set; }
        public decimal Amount { get; private set; }
        public ETransactionType Type { get; private set; }
        public DateTime Date { get; private set; }
        public Guid AccountId { get; private set; }
        public Account Account { get; private set; }
        public Guid CategoryId { get; private set; }
        public Category Category { get; private set; }
        public EPaymentMethod PaymentMethod { get; private set; }

        public Transaction(
            string description,
            decimal amount,
            ETransactionType type,
            DateTime date,
            Guid accountId,
            Guid categoryId,
            EPaymentMethod paymentMethod
            )
        {
            if(amount <= 0)
                throw new ArgumentException("O valor da transação deve ser maior que zero.", nameof(amount));
            
            Description = description;
            Amount = amount;
            Type = type;
            Date = date;
            AccountId = accountId;
            CategoryId = categoryId;
            PaymentMethod = paymentMethod;
        }
    }
}
