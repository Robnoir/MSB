using Domain.Models.BoxModel;
using Infrastructure.Repositories.BoxRepo;

namespace Application.Queries.Box.GetByID
{
    public class GetBoxByIdQueryHandler
    {
        private readonly IBoxRepository _boxRepository;

        public GetBoxByIdQueryHandler(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<BoxModel> Handle(GetBoxByIdQuery request, CancellationToken cancellationToken)
        {
            return await _boxRepository.GetBoxByIdAsync(request.BoxId);
        }
    }
}
