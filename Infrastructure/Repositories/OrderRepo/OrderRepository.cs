using Domain.Models.Order;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.OrderRepo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly MSB_Database _database;
        public OrderRepository(MSB_Database mSB_Database)
        {
            _database = mSB_Database;
        }

        public async Task<OrderModel> AddOrderAsync(OrderModel order)
        {
            await _database.Orders.AddAsync(order);
            await _database.SaveChangesAsync();

            return order;
        }

        public async Task<IEnumerable<OrderModel>> GetAllOrdersAsync()
        {
            return await _database.Orders.ToListAsync();
        }

        public async Task<OrderModel> GetOrderByIdAsync(Guid orderId)
        {
            return await _database.Orders.FindAsync(orderId);
        }

        public async Task<OrderModel> UpdateOrderAsync(OrderModel order)
        {
            _database.Orders.Update(order);
            await _database.SaveChangesAsync();

            return order;
        }

        public async Task DeleteOrderAsync(Guid orderId)
        {
            var order = await _database.Orders.FindAsync(orderId);
            if (order != null)
            {
                _database.Orders.Remove(order);
                await _database.SaveChangesAsync();
            }
        }

        public async Task<int> GetHighestOrderNumberAsync()
        {
            if (await _database.Orders.AnyAsync())
            {
                return await _database.Orders.MaxAsync(o => o.OrderNumber);
            }
            else
            {
                return 0;
            }
        }

        public async Task CreateOrderAsync(OrderModel newOrder)
        {
            await _database.Orders.AddAsync(newOrder);
            await _database.SaveChangesAsync();
        }
    }
}
