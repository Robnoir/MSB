using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Dto.User;
using Domain.Models.User;
using Application.Dto.Register;
using Domain.Models.User;

public class AddUserCommand : IRequest<UserModel>
{
    public RegisterDto RegisterData { get; }

    public AddUserCommand(RegisterDto registerData)
    {
        RegisterData = registerData;
    }
}
