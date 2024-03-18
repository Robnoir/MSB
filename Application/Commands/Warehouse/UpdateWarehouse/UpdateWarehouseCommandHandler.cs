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
            return await _warehouseRepository.UpdateWarehouseAsync(request.Warehouse);
        }
    }
}
