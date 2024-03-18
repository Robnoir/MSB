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
            try
            {
                UserModel userToCreate = new()
                {
                    UserId = Guid.NewGuid(),
                    Email = request.NewUser.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.NewUser.Password),
                    FirstName = request.NewUser.FirstName,
                    LastName = request.NewUser.LastName,

                };

                return userToCreate;
            }
            catch (Exception ex)
            {
                var newExeption = new Exception($"An error occurred while adding a new user: {request.NewUser.Email}", ex);

                throw newExeption;
            }
           

            
        }
    }
}
