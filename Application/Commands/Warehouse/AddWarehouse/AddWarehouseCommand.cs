using Application.Dto.Warehouse;
using Domain.Models.Warehouse;
using MediatR;

namespace Application.Commands.Warehouse.AddWarehouse
{
    public class AddWarehouseCommand : IRequest<WarehouseModel>
    {
        public AddWarehouseCommand(WarehouseDto newWarehouse)
        {
            NewWarehouse = newWarehouse;
        }
        public WarehouseDto NewWarehouse { get; }
    }
}
