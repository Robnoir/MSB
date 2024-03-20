using Domain.Models.Address;
using MediatR;

namespace Application.Queries.Address.GetByID
{
    public class GetAddressByIdQuery : IRequest<AddressModel>
    {
        public Guid AddressId { get; }
        public GetAddressByIdQuery(Guid addressId)
        {
            AddressId = addressId;
        }
    }
}
