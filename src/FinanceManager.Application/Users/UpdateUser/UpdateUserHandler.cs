using FinanceManager.Domain.Users;
using MediatR;

namespace FinanceManager.Application.Users.UpdateUser
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserCommand request, CancellationToken ct)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user is null)
                throw new KeyNotFoundException("Usuário não encontrado");

            user.Update(request.Name, request.Email);

            await _userRepository.UpdateAsync(user);

            return new UpdateUserResponse(user.Id, user.Name, user.Email);
        }
    }
}
