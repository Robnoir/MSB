using Application.Dto.UpdateUserInfo;
using Application.Dto.User;
using Domain.Models.User;
using MediatR;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public UpdateUserInfoDto UpdateUserInfoDto { get; }
        public Guid UserId { get; }

        public string UpdatePassword { get; set; }

        public UpdateUserCommand(UpdateUserInfoDto userInfoDto, Guid userId)
        {
            UpdateUserInfoDto = userInfoDto;
            UserId = userId;
        }
    }
}
