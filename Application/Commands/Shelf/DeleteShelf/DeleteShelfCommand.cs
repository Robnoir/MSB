using MediatR;

namespace Application.Commands.Shelf.DeleteShelf
{
    public class DeleteShelfCommand : IRequest<Unit>
    {
        public Guid ShelfId { get; set; }
        public DeleteShelfCommand(Guid shelfId)
        {
            ShelfId = shelfId;
        }
    }
}
