using Infrastructure.Repositories.AddressRepo;
using MediatR;

namespace Application.Commands.Address.DeleteAddress
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, Unit>
    {
        private readonly IAddressRepository _addressRepository;

        public DeleteAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            await _addressRepository.DeleteAddressAsync(request.AddressId);
            return Unit.Value;
        }
    }
}
