using Application.Dto.User;
using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserModel>
    {
        public UserDto UpdateUserDto { get; }
        public Guid UserId { get; }

        public string UpdatePassword  { get; set; }

        public UpdateUserCommand(UserDto userDto, Guid userId)
        {
            UpdateUserDto = userDto;
            UserId = userId;

                
        }
    }
}
