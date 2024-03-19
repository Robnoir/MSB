using Domain.Models.Warehouse;
using MediatR;

namespace Application.Commands.Warehouse.AddWarehouse
{
    public class AddWarehouseCommandHandler : IRequestHandler<AddWarehouseCommand, WarehouseModel>
    {
        public async Task<WarehouseModel> Handle(AddWarehouseCommand request, CancellationToken cancellationToken)
        {
            WarehouseModel warehouseToCreate = new()
            {
                WarehouseId = Guid.NewGuid(),
                WarehouseName = request.NewWarehouse.WarehouseName,
                // AdressId = request.NewWarehouse.AdressId,
                // ShelfId = request.NewWarehouse.ShelfId
            };

            return warehouseToCreate;
        }
    }
}
