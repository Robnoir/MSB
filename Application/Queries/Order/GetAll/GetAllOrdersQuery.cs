using Domain.Models.Order;
using MediatR;

namespace Application.Queries.Order.GetAll
{
    public class GetAllOrdersQuery : IRequest<IEnumerable<OrderModel>>
    {
    }
}
