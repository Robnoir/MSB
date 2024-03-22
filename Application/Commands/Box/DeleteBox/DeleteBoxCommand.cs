using MediatR;

namespace Application.Commands.Box.DeleteBox
{
    public class DeleteBoxCommand : IRequest<Unit>
    {
        public Guid BoxId { get; set; }
        public DeleteBoxCommand(Guid boxId)
        {
            BoxId = boxId;
        }
    }
}