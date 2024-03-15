using Application.Commands.Users.AddUser;
using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserModel>
    {
        public async Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            UserModel userToCreate = new()
            {
                Id = Guid.NewGuid(),
                Email = request.NewUser.Email,
                Password = request.NewUser.Password,
                FirstName = request.NewUser.FirstName,
                LastName = request.NewUser.LastName,

            };

            return userToCreate;
        }
    }
}
