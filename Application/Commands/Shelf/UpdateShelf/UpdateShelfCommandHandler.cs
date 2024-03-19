using Domain.Models.Shelf;
using Infrastructure.Repositories.ShelfRepo;
using MediatR;

namespace Application.Commands.Shelf.UpdateShelf
{
    public class UpdateShelfCommandHandler : IRequestHandler<UpdateShelfCommand, ShelfModel>
    {
        private readonly IShelfRepository _shelfRepository;
        public UpdateShelfCommandHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<ShelfModel> Handle(UpdateShelfCommand request, CancellationToken cancellationToken)
        {
            ShelfModel shelfToUpdate = new ShelfModel
            {
                ShelfId = request.UpdatedShelf.ShelfId,
                ShelfRow = request.UpdatedShelf.ShelfRow,
                ShelfColumn = request.UpdatedShelf.ShelfColumn,
                Occupancy = request.UpdatedShelf.Occupancy,
                WarehouseId = request.UpdatedShelf.WarehouseId,
                // BoxId = request.UpdatedShelf.BoxId, // Pending implementation
                // ItemId = request.UpdatedShelf.ItemId, // Pending implementation

            };

            return await _shelfRepository.UpdateShelfAsync(shelfToUpdate);
        }
    }
}
