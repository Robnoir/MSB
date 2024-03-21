using Domain.Models.Warehouse;
using Infrastructure.Repositories.WarehouseRepo;
using MediatR;

namespace Application.Queries.Warehouse.GetAll
{
    public class GetAllWarehousesQueryHandler : IRequestHandler<GetAllWarehousesQuery, IEnumerable<WarehouseModel>>
    {
        private readonly IWarehouseRepository _warehouseRepository;
        public GetAllWarehousesQueryHandler(IWarehouseRepository warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
        }
        public async Task<IEnumerable<WarehouseModel>> Handle(GetAllWarehousesQuery request, CancellationToken cancellationToken)
        {
            return await _warehouseRepository.GetAllWarehousesAsync();
        }
    }
}
