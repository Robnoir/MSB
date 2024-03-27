using Domain.Models.Address;
using MediatR;

namespace Application.Commands.Address.AddAddress
{
    public class AddAddressCommandHandler : IRequestHandler<AddAddressCommand, AddressModel>
    {
        public async Task<AddressModel> Handle(AddAddressCommand request, CancellationToken cancellationToken)
        {
            AddressModel addressToCreate = new()
            {
                AddressId = Guid.NewGuid(),
                StreetName = request.NewAddress.StreetName ?? string.Empty,
                StreetNumber = request.NewAddress.StreetNumber ?? string.Empty,
                Apartment = request.NewAddress.Apartment,
                ZipCode = request.NewAddress.ZipCode ?? string.Empty,
                Floor = request.NewAddress.Floor,

                // Additional geographic information

                City = request.NewAddress.City,
                State = request.NewAddress.State,
                Country = request.NewAddress.Country,
                Latitude = request.NewAddress.Latitude,
                Longitude = request.NewAddress.Longitude,


            };

            return addressToCreate;
        }
    }
}