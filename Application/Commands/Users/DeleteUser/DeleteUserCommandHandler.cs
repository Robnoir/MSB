using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserModel>
    {

        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<UserModel>Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UserModel userToDelete = await _userRepository.GetUserByIdAsync(request.Id);

                if (userToDelete == null)
                {
                    throw new InvalidOperationException("No user with the given id was found");
                }

                await _userRepository.DeleteUserAsync(request.Id);

                return userToDelete;

            }
            catch (Exception ex) 
            {
                 var newException = new Exception($"An Error occurred when deleteting user with id {request.Id}", ex);
                throw newException;
            }

            
        }
  

    }
}
