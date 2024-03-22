using Domain.Models.OrderModel;
using Infrastructure.Repositories.OrderRepo;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderModel> CreateOrderAsync(OrderModel newOrder)
    {
        while (true)
        {
            try
            {
                // Get the highest order number
                int highestOrderNumber = await _orderRepository.GetHighestOrderNumberAsync();

                // Extract the order number part and increment it
                int orderNumberPart = highestOrderNumber % 10000;
                orderNumberPart++;

                // Get the current year and month
                var year = DateTime.Now.Year % 100; // Get the last two digits of the current year
                var month = DateTime.Now.Month;

                // Combine the year, month, and order number parts
                newOrder.OrderNumber = year * 1000000 + month * 10000 + orderNumberPart;

                // Save the new order
                await _orderRepository.CreateOrderAsync(newOrder);

                return newOrder;
            }
            catch (DbUpdateException ex) when (IsDuplicateKeyException(ex))
            {
                // If a duplicate key exception occurred, retry the operation
                continue;
            }
        }
    }

    private bool IsDuplicateKeyException(DbUpdateException ex)
    {
        var mysqlException = ex.InnerException as MySqlException;
        if (mysqlException != null)
        {
            // Error code 1062 is for duplicate key exceptions
            return mysqlException.Number == 1062;
        }

        return false;
    }
}
