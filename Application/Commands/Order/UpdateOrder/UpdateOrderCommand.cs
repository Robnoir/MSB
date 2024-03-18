using Domain.Models.OrderModel;
using MediatR;

namespace Application.Commands.Order.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<OrderModel>
    {
        public OrderModel Order { get; set; }

        public UpdateOrderCommand(OrderModel order)
        {
            Order = order;
        }
    }
}
