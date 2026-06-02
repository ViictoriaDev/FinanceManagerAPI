namespace FinanceManager.Application.Users.CreateUser
{
    public record CreateUserResponse(
        Guid Id,
        string Name,
        string Email
    );
}