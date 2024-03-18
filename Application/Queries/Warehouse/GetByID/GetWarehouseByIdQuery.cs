using Domain.Models.Warehouse;
using MediatR;

namespace Application.Queries.Warehouse.GetByID
{
    public class GetWarehouseByIdQuery : IRequest<WarehouseModel>
    {
        public Guid WarehouseId { get; }
        public GetWarehouseByIdQuery(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
