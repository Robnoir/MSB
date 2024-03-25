using Application.Dto.AddShelf;
using Domain.Models.Shelf;
using MediatR;

namespace Application.Commands.Shelf.AddShelf
{
    public class AddShelfCommand : IRequest<ShelfModel>
    {
        public AddShelfCommand(AddShelfDto newShelf)
        {
            NewShelf = newShelf;
        }
        public AddShelfDto NewShelf { get; }
    }
}
