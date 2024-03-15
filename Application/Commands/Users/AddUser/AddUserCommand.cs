﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.User;
using Domain.Models;

namespace Application.Commands.Users.AddUser
{
    public class AddUserCommand : IRequest<User>
    {

        public AddUserCommand(UserDto newUser)
        {
            NewUser = newUser;
        }
        public UserDto NewUser { get; }

    }
}