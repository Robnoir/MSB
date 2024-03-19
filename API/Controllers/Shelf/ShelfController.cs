using MediatR;

namespace API.Controllers.Shelf
{
    public class ShelfController
    {
        private readonly IMediator _mediator;
        public ShelfController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
