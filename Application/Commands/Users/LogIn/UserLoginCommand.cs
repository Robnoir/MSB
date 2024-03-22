using Application.Dto.LogIn;
using Domain.Models.User;
using MediatR;

namespace Application.Commands.Users.LogIn
{
    public class UserLoginCommand : IRequest<UserModel>
    {
        public LogInDto logInDtos { get; set; }

        public UserLoginCommand(LogInDto logInDto)
        {
            logInDtos = logInDto;
        }
    }

}

