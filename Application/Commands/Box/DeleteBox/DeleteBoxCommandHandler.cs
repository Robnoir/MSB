using Infrastructure.Repositories.BoxRepo;
using MediatR;

namespace Application.Commands.Box.DeleteBox
{
    public class DeleteBoxCommandHandler : IRequestHandler<DeleteBoxCommand, Unit>
    {
        private readonly IBoxRepository _boxRepository;

        public DeleteBoxCommandHandler(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<Unit> Handle(DeleteBoxCommand request, CancellationToken cancellationToken)
        {
            await _boxRepository.DeleteBoxAsync(request.BoxId);
            return Unit.Value;
        }

    }
}
