using FinanceManager.Domain.Users;

namespace FinanceManager.Application.Users.GetAllUsers
{
    public record UserDto(Guid Id, string Name, string Email);
    public record GetAllUsersResponse(IEnumerable<UserDto> Users);
}
