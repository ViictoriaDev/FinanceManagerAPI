using FinanceManager.Domain.Users;
using MediatR;

namespace FinanceManager.Application.Users.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken ct)
        {
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);

            if (existingUser is not null)
                throw new InvalidOperationException("Já existe um usuário com esse e-mail!");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User(request.Name, request.Email, passwordHash);

            await _userRepository.AddAsync(user);

            return new CreateUserResponse(user.Id, user.Name, user.Email);
        }
    }
}
