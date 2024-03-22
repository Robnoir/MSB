using Infrastructure.Repositories.WarehouseRepo;
using MediatR;

namespace Application.Commands.Warehouse.DeleteWarehouse
{
    public class DeleteWarehouseCommandHandler : IRequestHandler<DeleteWarehouseCommand, Unit>
    {
        private readonly IWarehouseRepository _warehouseRepository;

        public DeleteWarehouseCommandHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }

        public async Task<Unit> Handle(DeleteWarehouseCommand request, CancellationToken cancellationToken)
        {
            await _warehouseRepository.DeleteWarehouseAsync(request.WarehouseId);
            return Unit.Value;
        }
    }
}

