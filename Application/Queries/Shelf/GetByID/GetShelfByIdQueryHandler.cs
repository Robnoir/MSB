using Domain.Models.Shelf;
using Infrastructure.Repositories.ShelfRepo;
using MediatR;

namespace Application.Queries.Shelf.GetByID
{
    public class GetShelfByIdQueryHandler : IRequestHandler<GetShelfByIdQuery, ShelfModel>
    {
        private readonly IShelfRepository _shelfRepository;
        public GetShelfByIdQueryHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<ShelfModel> Handle(GetShelfByIdQuery request, CancellationToken cancellationToken)
        {
            return await _shelfRepository.GetShelfByIdAsync(request.ShelfId);
        }
    }
}
