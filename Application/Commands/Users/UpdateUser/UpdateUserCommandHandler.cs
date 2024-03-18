using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

       public async Task<UserModel> Handle(UpdateUserCommand command,CancellationToken cancellationToken)
        {

            var user = await _userRepository.GetUserByIdAsync(command.UserId);

            try
            {
                if (!string.IsNullOrWhiteSpace(command.NewPasswordHash))
                {
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.NewPasswordHash);
                }

                if (!string.IsNullOrWhiteSpace(command.UpdateUserDto.Email))
                {
                    user.Email = command.UpdateUserDto.Email;
                }

                await _userRepository.UpdateUserAsync(user);

                return user;

            }
            catch (Exception ex)
            {
                var newException = new Exception($"An error occurred while updating user with ID: {command.UserId}",ex);
                throw newException;
            }
        }
       


    }
}
