using Domain.Models.OrderModel;
using MediatR;

namespace Application.Queries.Order.GetByID
{
    public class GetOrderByIdQuery : IRequest<OrderModel>
    {
        public Guid OrderId { get; }
        public GetOrderByIdQuery(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
