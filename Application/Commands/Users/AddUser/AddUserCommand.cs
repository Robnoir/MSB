using MediatR;
using Application.Dto.Register;
using Domain.Models.UserModel;

public class AddUserCommand : IRequest<UserModels>
{
    public RegisterDto RegisterData { get; }

    public AddUserCommand(RegisterDto registerData)
    {
        RegisterData = registerData;
    }
}
