using Domain.Models.BoxModel;
using MediatR;

namespace Application.Queries.Box.GetAll
{
    public class GetAllBoxesQuery : IRequest<IEnumerable<BoxModel>>
    {
    }
}
