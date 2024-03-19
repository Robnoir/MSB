using Domain.Models.UserModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.User.GetAll
{
    public class GetAllUsersQuery : IRequest<List<UserModels>>
    {

    }
}
