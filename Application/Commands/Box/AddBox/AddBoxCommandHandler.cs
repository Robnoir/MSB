using Domain.Models.BoxModel;
using MediatR;

namespace Application.Commands.Box.AddBox
{
    public class AddBoxCommandHandler : IRequestHandler<AddBoxCommand, BoxModel>
    {
        public async Task<BoxModel> Handle(AddBoxCommand request, CancellationToken cancellationToken)
        {
            BoxModel boxToCreate = new()
            {
                BoxId = Guid.NewGuid(),
                Type = request.NewBox.Type,
                TimesUsed = request.NewBox.TimesUsed,
                Stock = request.NewBox.Stock,
                ImageUrl = request.NewBox.ImageUrl,
                UserNotes = request.NewBox.UserNotes,
                Size = request.NewBox.Size
            };
            return boxToCreate;
        }
    }
}
