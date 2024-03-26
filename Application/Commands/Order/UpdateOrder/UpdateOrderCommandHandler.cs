using Domain.Models.Order;
using Infrastructure.Repositories.OrderRepo;
using MediatR;

namespace Application.Commands.Order.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, OrderModel>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<OrderModel> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            OrderModel orderToUpdate = new OrderModel
            {
                OrderId = request.Order.OrderId,
                OrderDate = request.Order.OrderDate,
                TotalCost = request.Order.TotalCost,
                OrderStatus = request.Order.OrderStatus,
                UserId = request.Order.UserId,
                RepairNotes = request.Order.RepairNotes
            };

            return await _orderRepository.UpdateOrderAsync(orderToUpdate);
        }
    }
}
