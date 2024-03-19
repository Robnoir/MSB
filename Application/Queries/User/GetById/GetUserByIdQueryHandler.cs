using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserModels>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }


        public async Task<UserModels> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            UserModels wantedUser = await _userRepository.GetUserByIdAsync(request.Id);
            try
            {
                if (wantedUser == null)
                {
                    return null!;
                }
                return wantedUser;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



    }
}
