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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, UserModels>
    {

        private readonly IUserRepository _userRepository;
        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public async Task<UserModels> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                UserModels userToDelete = await _userRepository.GetUserByIdAsync(request.Id);

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
