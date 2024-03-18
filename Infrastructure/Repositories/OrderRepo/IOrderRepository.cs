using Domain.Models.OrderModel;

namespace Infrastructure.Repositories.OrderRepo
{
    public interface IOrderRepository
    {
        Task<OrderModel> AddOrderAsync(OrderModel order);
        Task<IEnumerable<OrderModel>> GetAllOrdersAsync();
        Task<OrderModel> GetOrderByIdAsync(Guid orderId);
        Task<OrderModel> UpdateOrderAsync(OrderModel order);
        Task DeleteOrderAsync(Guid orderId);
    }
}
