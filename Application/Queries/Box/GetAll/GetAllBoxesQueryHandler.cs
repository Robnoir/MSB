using Domain.Models.BoxModel;
using Infrastructure.Repositories.BoxRepo;
using MediatR;

namespace Application.Queries.Box.GetAll
{
    public class GetAllBoxesQueryHandler : IRequestHandler<GetAllBoxesQuery, IEnumerable<BoxModel>>
    {
        private readonly IBoxRepository _boxRepository;
        public GetAllBoxesQueryHandler(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<IEnumerable<BoxModel>> Handle(GetAllBoxesQuery request, CancellationToken cancellationToken)
        {
            return await _boxRepository.GetAllBoxesAsync();
        }
    }
}
