using Application.Dto.User;
using Domain.Models.User;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public UserDto UpdateUserDto { get; }
        public Guid UserId { get; }

        public string UpdatePassword { get; set; }

        public UpdateUserCommand(UserDto userDto, Guid userId)
        {
            UpdateUserDto = userDto;
            UserId = userId;
        }
    }
}
