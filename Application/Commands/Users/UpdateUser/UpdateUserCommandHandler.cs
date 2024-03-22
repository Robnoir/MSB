﻿using Domain.Models.UserModel;
using Infrastructure.Repositories.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModels> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(command.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            user.Email = command.UpdateUserDto.Email ?? user.Email;
            user.FirstName = command.UpdateUserDto.FirstName ?? user.FirstName;
            user.LastName = command.UpdateUserDto.LastName ?? user.LastName;


            await _userRepository.UpdateUserAsync(user);

            return user;



        }



    }
}