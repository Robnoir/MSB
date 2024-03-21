using Domain.Models.Address;
using MediatR;

namespace Application.Commands.Address.AddAddress
{
    public class AddAddressCommand : IRequest<AddressModel>
    {
        public AddAddressCommand(AddressModel newAddress)
        {
            NewAddress = newAddress;
        }
        public AddressModel NewAddress { get; }
    }
}
