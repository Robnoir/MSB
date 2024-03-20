using Domain.Models.Address;
using MediatR;

namespace Application.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommand : IRequest<AddressModel>
    {
        public AddressModel Address { get; set; }

        public UpdateAddressCommand(AddressModel address)
        {
            Address = address;
        }
    }
}
