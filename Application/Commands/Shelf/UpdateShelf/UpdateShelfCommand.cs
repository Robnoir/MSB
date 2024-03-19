using Application.Dto.Shelf;
using Domain.Models.Shelf;
using MediatR;

namespace Application.Commands.Shelf.UpdateShelf
{
    public class UpdateShelfCommand : IRequest<ShelfModel>
    {
        public UpdateShelfCommand(ShelfDto updatedShelf)
        {
            UpdatedShelf = updatedShelf;
        }
        public ShelfDto UpdatedShelf { get; }
    }
}
