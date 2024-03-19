using Application.Commands.Warehouse.AddWarehouse;
using Application.Commands.Warehouse.DeleteWarehouse;
using Application.Commands.Warehouse.UpdateWarehouse;
using Application.Queries.Warehouse.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Warehouse
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WarehouseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouse([FromBody] AddWarehouseCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(AddWarehouse), result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(Guid id)
        {
            await _mediator.Send(new DeleteWarehouseCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWarehouse([FromBody] UpdateWarehouseCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouses()
        {
            var query = new GetAllWarehousesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
