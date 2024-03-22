using Domain.Models.BoxModel;
using Infrastructure.Repositories.BoxRepo;
using MediatR;

namespace Application.Commands.Box.UpdateBox
{
    public class UpdateBoxCommandHandler : IRequestHandler<UpdateBoxCommand, BoxModel>
    {
        private readonly IBoxRepository _boxRepository;
        public UpdateBoxCommandHandler(IBoxRepository boxRepository)
        {
            _boxRepository = boxRepository;
        }

        public async Task<BoxModel> Handle(UpdateBoxCommand request, CancellationToken cancellationToken)
        {

            BoxModel boxToUpdate = new BoxModel
            {
                BoxId = request.Box.BoxId,
                Type = request.Box.Type,
                TimesUsed = request.Box.TimesUsed,
                Stock = request.Box.Stock,
                ImageUrl = request.Box.ImageUrl,
                UserNotes = request.Box.UserNotes,
                Size = request.Box.Size

            };
            return await _boxRepository.UpdateBoxAsync(boxToUpdate);
        }
    }
}