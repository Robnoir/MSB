using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User.GetById
{
    public class GetUserByIdQuery : IRequest<UserModel>
    {
        public GetUserByIdQuery(Guid userId)
        {
            
            Id = userId;
        }

        public Guid Id { get;  }
    }
}
