using MediatR;

namespace Application.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommand : IRequest<Unit>
    {
        public Guid AddressId { get; set; }

        public DeleteAddressCommand(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}
