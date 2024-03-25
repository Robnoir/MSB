using Application.Commands.Shelf.AddShelf;
using Application.Commands.Shelf.DeleteShelf;
using Application.Commands.Shelf.UpdateShelf;
using Application.Dto.Shelf;
using Application.Queries.Shelf.GetAll;
using Application.Queries.Shelf.GetByID;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Shelf
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelfController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ShelfController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("Add Shelf")]
        public async Task<ActionResult<ShelfDto>> AddShelf(AddShelfCommand command)
        {
            var shelf = await _mediator.Send(command);
            var shelfDto = new ShelfDto
            {
                ShelfId = shelf.ShelfId,
                ShelfRow = shelf.ShelfRow,
                ShelfColumn = shelf.ShelfColumn,
                Occupancy = shelf.Occupancy,
                WarehouseId = shelf.WarehouseId
            };
            return CreatedAtAction(nameof(GetShelfById), new { id = shelfDto.ShelfId }, shelfDto);
        }

        [HttpGet]
        [Route("Get All Shelves")]
        public async Task<ActionResult<IEnumerable<ShelfDto>>> GetAllShelves()
        {
            var query = new GetAllShelvesQuery();
            var shelves = await _mediator.Send(query);
            var shelfDtos = shelves.Select(shelf => new ShelfDto
            {
                ShelfId = shelf.ShelfId,
                ShelfRow = shelf.ShelfRow,
                ShelfColumn = shelf.ShelfColumn,
                Occupancy = shelf.Occupancy,
                WarehouseId = shelf.WarehouseId
            });
            return Ok(shelfDtos);
        }

        [HttpGet("Get Shelf By {id}")]
        public async Task<ActionResult<ShelfDto>> GetShelfById(Guid id)
        {
            var query = new GetShelfByIdQuery(id);
            var shelf = await _mediator.Send(query);

            if (shelf == null)
            {
                return NotFound();
            }

            var shelfDto = new ShelfDto
            {
                ShelfId = shelf.ShelfId,
                ShelfRow = shelf.ShelfRow,
                ShelfColumn = shelf.ShelfColumn,
                Occupancy = shelf.Occupancy,
                WarehouseId = shelf.WarehouseId
            };
            return Ok(shelfDto);
        }

        [HttpPut("Update Shelf By {id}")]
        public async Task<IActionResult> UpdateShelf(Guid id, ShelfDto shelfDto)
        {
            if (id != shelfDto.ShelfId)
            {
                return BadRequest();
            }

            var command = new UpdateShelfCommand(shelfDto);
            var updatedShelf = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("Delete Shelf By {id}")]
        public async Task<IActionResult> DeleteShelf(Guid id)
        {
            var command = new DeleteShelfCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
