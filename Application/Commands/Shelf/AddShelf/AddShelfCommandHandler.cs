using Domain.Models.Shelf;
using Infrastructure.Repositories.ShelfRepo;
using MediatR;

namespace Application.Commands.Shelf.AddShelf
{
    public class AddShelfCommandHandler : IRequestHandler<AddShelfCommand, ShelfModel>
    {
        private readonly IShelfRepository _shelfRepository;
        public AddShelfCommandHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<ShelfModel> Handle(AddShelfCommand request, CancellationToken cancellationToken)
        {
            ShelfModel shelfToCreate = new()
            {
                ShelfId = Guid.NewGuid(),
                ShelfRow = request.NewShelf.ShelfRow,
                ShelfColumn = request.NewShelf.ShelfColumn,
                Occupancy = request.NewShelf.Occupancy,
                WarehouseId = request.NewShelf.WarehouseId,
            };

            return await _shelfRepository.AddShelfAsync(shelfToCreate);
        }
    }
}
