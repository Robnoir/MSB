using Domain.Models.Warehouse;
using Infrastructure.Repositories.WarehouseRepo;
using MediatR;

namespace Application.Commands.Warehouse.UpdateWarehouse
{
    public class UpdateWarehouseCommandHandler : IRequestHandler<UpdateWarehouseCommand, WarehouseModel>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public UpdateWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<WarehouseModel> Handle(UpdateWarehouseCommand request, CancellationToken cancellationToken)
        {
            WarehouseModel warehouseToUpdate = new WarehouseModel
            {
                WarehouseId = request.Warehouse.WarehouseId,
                WarehouseName = request.Warehouse.WarehouseName,
                // AddressId = request.Warehouse.AddressId, // Comment until implemented
                // ShelfId = request.Warehouse.ShelfId // Comment until implemented


            };

            return await _warehouseRepository.UpdateWarehouseAsync(warehouseToUpdate);
        }
    }
}
