using Infrastructure.Repositories.ShelfRepo;
using MediatR;

namespace Application.Commands.Shelf.DeleteShelf
{
    public class DeleteShelfCommandHandler : IRequestHandler<DeleteShelfCommand, Unit>
    {
        private readonly IShelfRepository _shelfRepository;
        public DeleteShelfCommandHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<Unit> Handle(DeleteShelfCommand request, CancellationToken cancellationToken)
        {
            await _shelfRepository.DeleteShelfAsync(request.ShelfId);
            return Unit.Value;
        }
    }
}
