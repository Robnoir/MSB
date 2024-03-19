using Domain.Models.Shelf;
using MediatR;

namespace Application.Queries.Shelf.GetAll
{
    public class GetAllShelvesQuery : IRequest<IEnumerable<ShelfModel>>
    {
    }
}
