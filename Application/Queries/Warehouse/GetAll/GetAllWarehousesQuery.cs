using Domain.Models.Warehouse;
using MediatR;

namespace Application.Queries.Warehouse.GetAll
{
    public class GetAllWarehousesQuery : IRequest<IEnumerable<WarehouseModel>>
    {
    }
}
