using Application.Dto.Box;
using Domain.Models.BoxModel;
using MediatR;

namespace Application.Commands.Box.UpdateBox
{
    public class UpdateBoxCommand : IRequest<BoxModel>
    {
        public BoxDto Box { get; set; }
        public UpdateBoxCommand(BoxDto box)
        {
            Box = box;
        }
    }
}