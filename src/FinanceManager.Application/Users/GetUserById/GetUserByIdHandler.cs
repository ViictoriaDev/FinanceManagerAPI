using FinanceManager.Domain.Users;
using MediatR;

namespace FinanceManager.Application.Users.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery query, CancellationToken ct)
        {
            var user = await _userRepository.GetByIdAsync(query.Id);

            if (user is null)
                throw new Exception("Usuário não encontrado!");

            return new GetUserByIdResponse(user.Id, user.Name, user.Email);
        }
    }
}
