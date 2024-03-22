using Domain.Models.User;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IUserRepository _userRepository;

        public GetAllUsersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            List<UserModel> allUsersFromDatabase = await _userRepository.GetAllUsersAsync();
            if (allUsersFromDatabase == null)
            {
                throw new InvalidOperationException("No Users was found");
            }
            return allUsersFromDatabase;
        }


    }
}
