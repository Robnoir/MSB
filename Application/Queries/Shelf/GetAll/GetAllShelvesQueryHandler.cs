using Domain.Models.Shelf;
using Infrastructure.Repositories.ShelfRepo;
using MediatR;

namespace Application.Queries.Shelf.GetAll
{
    public class GetAllShelvesQueryHandler : IRequestHandler<GetAllShelvesQuery, IEnumerable<ShelfModel>>
    {
        private readonly IShelfRepository _shelfRepository;
        public GetAllShelvesQueryHandler(IShelfRepository shelfRepository)
        {
            _shelfRepository = shelfRepository;
        }
        public async Task<IEnumerable<ShelfModel>> Handle(GetAllShelvesQuery request, CancellationToken cancellationToken)
        {
            return await _shelfRepository.GetAllAsync();
        }
    }
}
