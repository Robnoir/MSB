using Domain.Models.User;
using MediatR;

namespace Application.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<UserModel>
    {
        public DeleteUserCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; }
    }
}
