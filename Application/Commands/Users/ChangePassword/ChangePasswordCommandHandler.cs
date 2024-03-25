using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net; // Import the bcrypt package namespace

namespace Application.Commands.Users.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public ChangePasswordCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
        {
            // Assuming UserId is a string that needs to be parsed into a Guid
            if (!Guid.TryParse(command.UserId, out Guid userId))
            {
                // Handle the parsing error
                return false;
            }

            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
            {
                // User not found, handle accordingly
                return false;
            }

            // Verify the current password
            if (!BCrypt.Net.BCrypt.Verify(command.CurrentPassword, user.PasswordHash))
            {
                // Current password does not match, handle accordingly
                return false;
            }

            // Attempt to update the password by setting the new hashed password and saving it to the repository
            var newHashedPassword = BCrypt.Net.BCrypt.HashPassword(command.NewPassword);
            user.PasswordHash = newHashedPassword;

            // The UpdatePasswordAsync method is responsible for both setting the new password hash
            // and saving the changes to the database.
            bool updateSucceeded = await _userRepository.UpdatePasswordAsync(user);

            // Return the result of the update attempt
            return updateSucceeded;
        }
    }
}
