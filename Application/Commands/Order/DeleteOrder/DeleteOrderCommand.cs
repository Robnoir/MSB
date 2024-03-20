using MediatR;

namespace Application.Commands.Order.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid OrderId { get; set; }

        public DeleteOrderCommand(Guid orderId)
        {
            OrderId = orderId;
        }
    }
}
