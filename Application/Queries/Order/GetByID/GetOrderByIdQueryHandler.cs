using Application.Queries.Order.GetByID;
using Domain.Models.Order;
using Infrastructure.Repositories.OrderRepo;
using MediatR;

public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, OrderModel>
{
    private readonly IOrderRepository _orderRepository;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<OrderModel> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        return await _orderRepository.GetOrderByIdAsync(request.OrderId);
    }
}