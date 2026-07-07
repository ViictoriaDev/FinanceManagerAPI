namespace FinanceManager.Application.Categories.GetCategoriesByUserId
{
    public record CategoriesByUserIdDto(Guid Id, string Name, Guid UserId);
    public record GetCategoriesByUserIdResponse(IEnumerable<CategoriesByUserIdDto> Categories);
}
