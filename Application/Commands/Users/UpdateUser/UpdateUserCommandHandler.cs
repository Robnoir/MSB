using Application.Dto.Adress;
using Domain.Models.Address;
using Domain.Models.User;
using Infrastructure.Repositories.UserRepo;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserModel>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserModel> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByIdAsync(command.UserId);
            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            // Initialize the Addresses collection if it's null
            user.Addresses ??= new List<AddressModel>();

            // Update properties if they are not null in the DTO
            user.Email = command.UpdateUserInfoDto.Email ?? user.Email;
            user.FirstName = command.UpdateUserInfoDto.FirstName ?? user.FirstName;
            user.LastName = command.UpdateUserInfoDto.LastName ?? user.LastName;
            user.PhoneNumber = command.UpdateUserInfoDto.PhoneNumber ?? user.PhoneNumber;

            // Update the Address if it's not null
            if (command.UpdateUserInfoDto.Address != null)
            {
                var addressDto = command.UpdateUserInfoDto.Address;
                // Assuming you want to update the first address or add a new one if none exists
                var addressToUpdate = user.Addresses.FirstOrDefault() ?? new AddressModel();
                if (!user.Addresses.Any())
                {
                    user.Addresses.Add(addressToUpdate);
                }

                // Update address properties
                addressToUpdate.StreetName = addressDto.StreetName ?? addressToUpdate.StreetName;
                addressToUpdate.StreetNumber = addressDto.StreetNumber ?? addressToUpdate.StreetNumber;
                addressToUpdate.Apartment = addressDto.Apartment ?? addressToUpdate.Apartment;
                addressToUpdate.ZipCode = addressDto.ZipCode ?? addressToUpdate.ZipCode;
                addressDto.Floor = addressDto.Floor ?? addressToUpdate.Floor;
                addressToUpdate.City = addressDto.City ?? addressToUpdate.City;
                addressToUpdate.State = addressDto.State ?? addressToUpdate.State;
                addressToUpdate.Country = addressDto.Country ?? addressToUpdate.Country;
                addressToUpdate.ZipCode = addressDto.ZipCode ?? addressToUpdate.ZipCode;
                // ... Update other address fields as necessary
            }

            await _userRepository.UpdateUserAsync(user);

            return user;
        }
    }
}
