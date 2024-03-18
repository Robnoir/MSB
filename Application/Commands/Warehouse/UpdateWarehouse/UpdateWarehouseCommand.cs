using Domain.Models.Warehouse;
using MediatR;

namespace Application.Commands.Warehouse.UpdateWarehouse
{
    public class UpdateWarehouseCommand : IRequest<WarehouseModel>
    {
        public WarehouseModel Warehouse { get; set; }
        public UpdateWarehouseCommand(WarehouseModel warehouse)
        {
            Warehouse = warehouse;
        }
    }
}
