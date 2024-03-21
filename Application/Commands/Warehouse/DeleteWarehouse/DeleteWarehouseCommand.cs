using MediatR;

namespace Application.Commands.Warehouse.DeleteWarehouse
{
    public class DeleteWarehouseCommand : IRequest<Unit>
    {
        public Guid WarehouseId { get; set; }
        public DeleteWarehouseCommand(Guid warehouseId)
        {
            WarehouseId = warehouseId;
        }
    }
}
