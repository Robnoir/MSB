using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModels>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<List<UserModels>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserModels> allUsersFromDatabase = await _userRepository.GetAllUsersAsync();
            if (allUsersFromDatabase == null)
            {
                throw new InvalidOperationException("No Users was found");
            }
            return allUsersFromDatabase;
        }


    }
}
