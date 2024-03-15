using Application.Commands.Users.AddUser;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, User>
    {
        public async Task<User> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            User userToCreate = new()
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
