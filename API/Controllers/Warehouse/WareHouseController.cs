using Application.Commands.Warehouse.AddWarehouse;
using Application.Commands.Warehouse.DeleteWarehouse;
using Application.Commands.Warehouse.UpdateWarehouse;
using Application.Dto.Warehouse;
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
        public async Task<ActionResult<WarehouseDto>> AddWarehouse([FromBody] AddWarehouseCommand command)
        {
            var warehouse = await _mediator.Send(command);
            var warehouseDto = new WarehouseDto
            {
                WarehouseId = warehouse.WarehouseId,
                WarehouseName = warehouse.WarehouseName
            };
            return CreatedAtAction(nameof(AddWarehouse), warehouseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(Guid id)
        {
            await _mediator.Send(new DeleteWarehouseCommand(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<WarehouseDto>> UpdateWarehouse([FromBody] UpdateWarehouseCommand command)
        {
            var warehouse = await _mediator.Send(command);
            var warehouseDto = new WarehouseDto
            {
                WarehouseId = warehouse.WarehouseId,
                WarehouseName = warehouse.WarehouseName
            };
            return Ok(warehouseDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarehouseDto>>> GetAllWarehouses()
        {
            var query = new GetAllWarehousesQuery();
            var warehouses = await _mediator.Send(query);
            var warehouseDtos = warehouses.Select(warehouse => new WarehouseDto
            {
                WarehouseId = warehouse.WarehouseId,
                WarehouseName = warehouse.WarehouseName
            });
            return Ok(warehouseDtos);
        }
    }
}
