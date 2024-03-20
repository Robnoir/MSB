using Domain.Models.Address;
using MediatR;

namespace Application.Queries.Address.GetAll
{
    public class GetAllAddressesQuery : IRequest<IEnumerable<AddressModel>>
    {
    }
}
