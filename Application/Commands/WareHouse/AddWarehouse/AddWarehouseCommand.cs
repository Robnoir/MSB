using Application.Dto.AddWarehouse;
using Domain.Models.Warehouse;
using MediatR;

namespace Application.Commands.Warehouse.AddWarehouse
{
    public class AddWarehouseCommand : IRequest<WarehouseModel>
    {
        public AddWarehouseCommand(AddWarehouseDto newWarehouse)
        {
            NewWarehouse = newWarehouse;
        }
        public AddWarehouseDto NewWarehouse { get; }
    }
}

