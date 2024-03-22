using Domain.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<UserModels> AddUserAsync(UserModels user);
        Task UpdateUserAsync(UserModels user);
        Task DeleteUserAsync(Guid id);
        Task<UserModels> GetUserByIdAsync(Guid id);

        Task<List<UserModels>> GetAllUsersAsync();

        Task<UserModels> GetByEmailAsync(string email);



    }
}
