using Domain.Models.Warehouse;
using Infrastructure.Repositories.WarehouseRepo;
using MediatR;

namespace Application.Queries.Warehouse.GetByID
{
    public class GetWarehouseByIdQueryHandler : IRequestHandler<GetWarehouseByIdQuery, WarehouseModel>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public GetWarehouseByIdQueryHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<WarehouseModel> Handle(GetWarehouseByIdQuery request, CancellationToken cancellationToken)
        {
            return await _warehouseRepository.GetWarehouseByIdAsync(request.WarehouseId);
        }
    }
}
