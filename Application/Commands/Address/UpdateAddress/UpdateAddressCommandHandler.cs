using Domain.Models.Address;
using Infrastructure.Repositories.AddressRepo;
using MediatR;

namespace Application.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, AddressModel>
    {
        private readonly IAddressRepository _addressRepository;

        public UpdateAddressCommandHandler(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<AddressModel> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            return await _addressRepository.UpdateAddressAsync(request.Address);
        }
    }
}
