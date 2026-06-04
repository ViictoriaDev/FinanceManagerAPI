using FinanceManager.Domain.Users;
using MediatR;

namespace FinanceManager.Application.Users.GetAllUsers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery query, CancellationToken ct)
        {
            var users = await _userRepository.GetAllAsync();

            var usersDto = users.Select(u => new UserDto(u.Id, u.Name, u.Email));

            return new GetAllUsersResponse(usersDto);
        }
    }
}
