using Application.Commands.Warehouse.AddWarehouse;
using Application.Commands.Warehouse.DeleteWarehouse;
using Application.Commands.Warehouse.UpdateWarehouse;
using Application.Dto.AddWarehouse;
using Application.Dto.Warehouse;
using Application.Queries.Warehouse.GetAll;
using Application.Queries.Warehouse.GetByID;
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

        [HttpPost("Add Warehouse")]
        public async Task<ActionResult<WarehouseDto>> AddWarehouse([FromBody] AddWarehouseCommand command)
        {
            var warehouse = await _mediator.Send(command);
            var addWarehouseDto = new AddWarehouseDto
            {
                WarehouseName = warehouse.WarehouseName
            };
            return CreatedAtAction(nameof(AddWarehouse), addWarehouseDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouse(Guid id)
        {
            await _mediator.Send(new DeleteWarehouseCommand(id));
            return NoContent();
        }

        [HttpPut("Update Warehouse")]
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

        [HttpGet("Get All WareHouses")]
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

        [HttpGet("Get Warehouse By {id}")]
        public async Task<ActionResult<WarehouseDto>> GetWarehouseById(Guid id)
        {
            var query = new GetWarehouseByIdQuery(id);
            var warehouse = await _mediator.Send(query);

            if (warehouse == null)
            {
                return NotFound();
            }

            var warehouseDto = new WarehouseDto
            {
                WarehouseId = warehouse.WarehouseId,
                WarehouseName = warehouse.WarehouseName
            };
            return Ok(warehouseDto);
        }
    }
}
