using Domain.Models.User;
using Infrastructure.Repositories.UserRepo;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(command.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.Email = command.UpdateUserDto.Email ?? user.Email;
            user.FirstName = command.UpdateUserDto.FirstName ?? user.FirstName;
            user.LastName = command.UpdateUserDto.LastName ?? user.LastName;


            await _userRepository.UpdateUserAsync(user);

            return user;
        }
    }
}
