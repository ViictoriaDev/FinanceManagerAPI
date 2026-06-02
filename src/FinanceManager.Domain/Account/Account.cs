
    namespace FinanceManager.Domain.Account
{
    public class Account : Entity
    {
        public string Name { get; private set; }
        public decimal Balance { get; private set; }
        public bool IsActive { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Account(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
            Balance = 0;
            IsActive = true;
        }

        public void Update(string name)
        {
            Name = name;
            SetUpdatedAt();
        }

        public void Activate()
        {
            IsActive = true;
            SetUpdatedAt();
        }

        public void DeActivate()
        {
            IsActive = false;
            SetUpdatedAt();
        }

        public void AddBalance(decimal amount)
        {
            Balance += amount;
            SetUpdatedAt();
        }

        public void SubtractBalance(decimal amount)
        {
            if (amount > Balance)
                throw new InvalidOperationException("Saldo insuficiente.");
            Balance -= amount;
            SetUpdatedAt();
        }   
    }
}
