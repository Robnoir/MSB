using Application.Dto.Box;
using Domain.Models.BoxModel;
using MediatR;

namespace Application.Commands.Box.AddBox
{
    public class AddBoxCommand : IRequest<BoxModel>
    {
        public AddBoxCommand(BoxDto newBox)
        {
            NewBox = newBox;
        }
        public BoxDto NewBox { get; }
    }
}