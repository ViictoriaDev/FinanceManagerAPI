namespace FinanceManager.Application.Account.GetAccountById
{
    public record GetAccountByIdResponse(Guid Id, string Name, Guid UserId);
}
