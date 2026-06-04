namespace FinanceManager.Application.Account.GetAccountsByUserId
{
    public record GetAccountByUserIdResponse(Guid Id, Guid UserId, string Name);
}
