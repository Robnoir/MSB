using Domain.Models.OrderModel;
using MediatR;

namespace Application.Commands.Order.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, OrderModel>
    {
        public async Task<OrderModel> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            OrderModel orderToCreate = new()
            {
                OrderId = Guid.NewGuid(),
                OrderDate = request.NewOrder.OrderDate,
                TotalCost = request.NewOrder.TotalCost,
                OrderStatus = request.NewOrder.OrderStatus ?? string.Empty,
                UserId = request.NewOrder.UserId,
                // User = request.NewOrder.User, // You'll need to map from UserDto to UserModel
                // CarId = request.NewOrder.CarId, // Uncomment if you want to set CarId
                // RepairId = request.NewOrder.RepairId, // Uncomment if you want to set RepairId
                // WarehouseId = request.NewOrder.WarehouseId, // Uncomment if you want to set WarehouseId
                AdressId = request.NewOrder.AdressId,
                // Address = request.NewOrder.Address, // You'll need to map from AddressDto to AddressModel
                RepairNotes = request.NewOrder.RepairNotes ?? "No notes"
            };

            return orderToCreate;
        }
    }
}
