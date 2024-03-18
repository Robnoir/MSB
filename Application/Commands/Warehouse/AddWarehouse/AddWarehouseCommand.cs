using Domain.Models.Warehouse;
using MediatR;

namespace Application.Commands.Warehouse.AddWarehouse
{
    public class AddWarehouseCommand : IRequest<WarehouseModel>
    {
        public AddWarehouseCommand(WarehouseModel newWarehouse)
        {
            NewWarehouse = newWarehouse;
        }
        public WarehouseModel NewWarehouse { get; }
    }
}
