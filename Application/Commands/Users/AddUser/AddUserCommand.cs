using Application.Dto.Register;
using Domain.Models.User;
using MediatR;

public class AddUserCommand : IRequest<UserModel>
{
    public RegisterDto RegisterData { get; }

    public AddUserCommand(RegisterDto registerData)
    {
        RegisterData = registerData;
    }
}
