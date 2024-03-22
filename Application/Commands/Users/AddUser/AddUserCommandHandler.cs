
using Application.Commands.Users;
using Domain.Models.User;
using MediatR;
using Domain.Models.Address;
using Infrastructure.Repositories.UserRepo;
using System.Threading;
using System.Threading.Tasks;
using Application.Dto.Register;

public class AddUserCommandHandler : IRequestHandler<AddUserCommand, UserModel>
{
    private readonly IUserRepository _userRepository;

    public AddUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserModel> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new UserModel
        {
            Email = request.RegisterData.Email,
            FirstName = request.RegisterData.FirstName,
            LastName = request.RegisterData.LastName,
            PhoneNumber = int.Parse(request.RegisterData.PhoneNumber),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.RegisterData.Password),
            Addresses = new List<AddressModel>()
        };


        if (request.RegisterData.Address != null)
        {
            newUser.Addresses.Add(new AddressModel
            {
                StreetName = request.RegisterData.Address.StreetName,
                StreetNumber = request.RegisterData.Address.StreetNumber,
                Apartment = request.RegisterData.Address.Apartment,
                ZipCode = request.RegisterData.Address.ZipCode,
                Floor = request.RegisterData.Address.Floor,
                City = request.RegisterData.Address.City,
                State = request.RegisterData.Address.State,
                Country = request.RegisterData.Address.Country,

            });
        }


        var savedUser = await _userRepository.AddUserAsync(newUser);

        return savedUser;
    }
}
