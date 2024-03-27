using Application.Dto.Order;
using Domain.Models.Order;
using MediatR;

namespace Application.Commands.Order.AddOrder
{
    public class AddOrderCommand : IRequest<OrderModel>
    {
        public AddOrderCommand(OrderDto newOrder)
        {
            NewOrder = newOrder;
        }
        public OrderDto NewOrder { get; }
    }
}
