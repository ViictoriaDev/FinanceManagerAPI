namespace FinanceManager.Domain.User
{
    public class User : Entity
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public bool IsActive { get; private set; }

        public User(string name, string email, string passwordHash, bool isActive)
        {
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            IsActive = true;
        }

        public void Update(string name, string email)
        {
            Name = name;
            Email = email;
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
    }
}
