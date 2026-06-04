using FinanceManager.Domain.Users;

namespace FinanceManager.Domain.Categorys
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; }

        public Category(string name, Guid userId)
        {
            Name = name;
            UserId = userId;
        }

        public void Update(string name)
        {
            Name = name;
            SetUpdatedAt();
        }
    }
}
