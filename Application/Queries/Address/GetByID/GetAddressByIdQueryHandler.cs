using Application.Queries.Address.GetByID;
using Domain.Models.Address;
using Infrastructure.Repositories.AddressRepo;
using MediatR;

public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, AddressModel>
{
    private readonly IAddressRepository _addressRepository;

    public GetAddressByIdQueryHandler(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<AddressModel> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
    {
        return await _addressRepository.GetAddressByIdAsync(request.AddressId);
    }
}
