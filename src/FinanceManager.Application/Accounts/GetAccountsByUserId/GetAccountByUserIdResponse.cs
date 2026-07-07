namespace FinanceManager.Application.Account.GetAccountsByUserId
{
    public record AccountDto(Guid Id, string Name, Guid UserId);
    public record GetAccountByUserIdResponse(IEnumerable<AccountDto> Accounts);
}
