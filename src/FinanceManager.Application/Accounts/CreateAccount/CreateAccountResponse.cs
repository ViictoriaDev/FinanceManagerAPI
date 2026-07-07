using FinanceManager.Application.Users.GetAllUsers;

namespace FinanceManager.Application.Accounts.CreateAccount
{
    public record CreateAccountResponse(Guid Id, string Name, Guid UserId);
}
