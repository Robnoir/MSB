using Domain.Models.User;
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
        Task UpdateUserAsync(UserModel user);
        Task DeleteUserAsync(Guid id);
        Task<UserModel> GetUserByIdAsync(Guid id);

        Task<List<UserModel>> GetAllUsersAsync();

        Task<UserModel> GetByEmailAsync(string email);

        Task<bool> UpdatePasswordAsync(UserModel user);



    }
}
