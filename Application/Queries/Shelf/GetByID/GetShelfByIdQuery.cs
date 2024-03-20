using Domain.Models.Shelf;
using MediatR;

namespace Application.Queries.Shelf.GetByID
{
    public class GetShelfByIdQuery : IRequest<ShelfModel>
    {
        public Guid ShelfId { get; }
        public GetShelfByIdQuery(Guid shelfId)
        {
            ShelfId = shelfId;
        }
    }
}
