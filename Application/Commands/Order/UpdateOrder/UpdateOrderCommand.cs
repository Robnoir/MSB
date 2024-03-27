using Application.Dto.Order;
using Domain.Models.Order;
using MediatR;

namespace Application.Commands.Order.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderModel>
    {
        public OrderDto Order { get; set; }

        public UpdateOrderCommand(OrderDto order)
        {
            Order = order;
        }
    }
}
