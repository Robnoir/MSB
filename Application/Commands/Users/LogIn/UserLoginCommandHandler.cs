using Domain.Models.User;
using Infrastructure.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;
namespace Application.Commands.Users.LogIn
{
    public class UserLoginCommandHandler
    {

        private readonly IUserRepository _userRepository;

        public UserLoginCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmailAsync(request.logInDtos.Email);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with Email '{request.logInDtos.Email}' couldn't be found");
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(request.logInDtos.Password, user.PasswordHash); ;
            if (!isPasswordValid)
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }


            return user;




        }







    }
}
