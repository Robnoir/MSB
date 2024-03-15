using Domain.Models.UserModel;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {

        private readonly MSB_Database _database;
        public UserRepository(MSB_Database mSB_Database)
        {
            _database = mSB_Database;
        }


        public async Task<UserModel> AddUserAsync(UserModel user)
        {
            _database.Users.AddAsync(user);
            _database.SaveChangesAsync();

            return await Task.FromResult(user);

        }
    }
}
