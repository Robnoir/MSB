using Domain.Models.User;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User.GetByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserModel>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByEmailQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<UserModel> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {

            if (string.IsNullOrWhiteSpace(request.Email))
            {
                throw new ArgumentException("Username cannot be null or empty", nameof(request.Email));
            }

            var user = _userRepository.GetByEmailAsync(request.Email);

            if (user == null)
            {
                throw new KeyNotFoundException($"User with Email '{request.Email}' couldn't be found");
            }

            return user;

        }
    }
}
