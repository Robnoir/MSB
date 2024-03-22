using Application.Dto.Warehouse;
using Domain.Models.Warehouse;
using MediatR;

namespace Application.Commands.Warehouse.UpdateWarehouse
{
    public class UpdateWarehouseCommand : IRequest<WarehouseModel>
    {
        public WarehouseDto Warehouse { get; set; }
        public UpdateWarehouseCommand(WarehouseDto warehouse)
        {
            Warehouse = warehouse;
        }
    }
}

