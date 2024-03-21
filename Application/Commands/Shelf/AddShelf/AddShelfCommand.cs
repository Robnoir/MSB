using Application.Dto.Shelf;
using Domain.Models.Shelf;
using MediatR;

namespace Application.Commands.Shelf.AddShelf
{
    public class AddShelfCommand : IRequest<ShelfModel>
    {
        public AddShelfCommand(ShelfDto newShelf)
        {
            NewShelf = newShelf;
        }
        public ShelfDto NewShelf { get; }
    }
}
