using Application.Commands.Box.AddBox;
using Application.Commands.Box.DeleteBox;
using Application.Commands.Box.UpdateBox;
using Application.Dto.Box;
using Application.Queries.Box.GetAll;
using Application.Queries.Box.GetByID;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.BoxController
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoxController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoxController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<BoxDto>> AddBox(AddBoxCommand command)
        {
            var box = await _mediator.Send(command);
            var boxDto = new BoxDto
            {
                BoxId = box.BoxId,
                Type = box.Type,
                TimesUsed = box.TimesUsed,
                Stock = box.Stock,
                ImageUrl = box.ImageUrl,
                UserNotes = box.UserNotes,
                // Order = box.Order,
                Size = box.Size,

            };
            return CreatedAtAction(nameof(GetBoxById), new { id = box.BoxId }, boxDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoxDto>>> GetAllBoxes()
        {
            var query = new GetAllBoxesQuery();
            var boxes = await _mediator.Send(query);
            var boxDtos = boxes.Select(box => new BoxDto
            {
                BoxId = box.BoxId,
                Type = box.Type,
                TimesUsed = box.TimesUsed,
                Stock = box.Stock,
                ImageUrl = box.ImageUrl,
                UserNotes = box.UserNotes,
                // Order = box.Order,
                Size = box.Size,
            });
            return Ok(boxDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoxDto>> GetBoxById(Guid id)
        {
            var query = new GetBoxByIdQuery(id);
            var box = await _mediator.Send(query);

            if (box == null)
            {
                return NotFound();
            }

            var boxDto = new BoxDto
            {
                BoxId = box.BoxId,
                Type = box.Type,
                TimesUsed = box.TimesUsed,
                Stock = box.Stock,
                ImageUrl = box.ImageUrl,
                UserNotes = box.UserNotes,
                // Order = box.Order,
                Size = box.Size,
            };

            return Ok(boxDto);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBox(Guid id, BoxDto boxDto)
        {
            if (id != boxDto.BoxId)
            {
                return BadRequest();
            }

            var command = new UpdateBoxCommand(boxDto);
            var updatedBox = await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBox(Guid id)
        {
            var command = new DeleteBoxCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
