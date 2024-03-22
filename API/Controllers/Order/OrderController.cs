using Application.Commands.Order.AddOrder;
using Application.Commands.Order.DeleteOrder;
using Application.Commands.Order.UpdateOrder;
using Application.Dto.Order;
using Application.Queries.Order.GetAll;
using Application.Queries.Order.GetByID;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Order
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Add Order")]
        public async Task<ActionResult<OrderDto>> AddOrder(AddOrderCommand command)
        {
            var order = await _mediator.Send(command);
            var orderDto = new OrderDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalCost = order.TotalCost,
                OrderStatus = order.OrderStatus,
                UserId = order.UserId,
                RepairNotes = order.RepairNotes
            };
            return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.OrderId }, orderDto);
        }

        [HttpGet]
        [Route("Get All Orders")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {
            var query = new GetAllOrdersQuery();
            var orders = await _mediator.Send(query);
            var orderDtos = orders.Select(order => new OrderDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalCost = order.TotalCost,
                OrderStatus = order.OrderStatus,
                UserId = order.UserId,
                RepairNotes = order.RepairNotes
            });
            return Ok(orderDtos);
        }

        [HttpGet("Get Order By {id}")]
        public async Task<ActionResult<OrderDto>> GetOrderById(Guid id)
        {
            var query = new GetOrderByIdQuery(id);
            var order = await _mediator.Send(query);

            if (order == null)
            {
                return NotFound();
            }

            var orderDto = new OrderDto
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate,
                TotalCost = order.TotalCost,
                OrderStatus = order.OrderStatus,
                UserId = order.UserId,
                RepairNotes = order.RepairNotes
            };
            return Ok(orderDto);
        }

        [HttpPut("Update Order By {id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, OrderDto orderDto)
        {
            if (id != orderDto.OrderId)
            {
                return BadRequest();
            }

            var command = new UpdateOrderCommand(orderDto);
            var updatedOrder = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("Delete Order By {id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var command = new DeleteOrderCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
