﻿using Domain.Models.User;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<UserModel>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
