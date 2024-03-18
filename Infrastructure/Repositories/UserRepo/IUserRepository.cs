using Domain.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<UserModel> AddUserAsync(UserModel user);
    }
}
