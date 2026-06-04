using FinanceManager.Domain.Users;
using MediatR;

namespace FinanceManager.Application.Users.DeactivateUser
{
    public class DeactivateUserHandler : IRequestHandler<DeactivateUserCommand, DeactivateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeactivateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeactivateUserResponse> Handle(DeactivateUserCommand request, CancellationToken ct)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
                throw new KeyNotFoundException("Usuário não encontrado");

            user.DeActivate();

            await _userRepository.UpdateAsync(user);

            return new DeactivateUserResponse(user.Id, user.IsActive);
        }
    }
}
