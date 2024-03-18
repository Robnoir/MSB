using Domain.Models.OrderModel;
using MediatR;

namespace Application.Commands.Order.AddOrder
{
    public class AddOrderCommand : IRequest<OrderModel>
    {
        public AddOrderCommand(OrderModel newOrder)
        {
            NewOrder = newOrder;
        }
        public OrderModel NewOrder { get; }
    }
}
