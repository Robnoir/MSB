using Domain.Models.UserModel;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
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


        public async Task<UserModels> AddUserAsync(UserModels user)
        {
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();

            return await Task.FromResult(user);

        }

        public Task DeleteUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModels>> GetAllUsersAsync()
        {
            return await _database.Users.ToListAsync();
        }

        public async Task<UserModels> GetUserByIdAsync(Guid id)
        {
            return await _database.Users.FindAsync(id);
        }

        public async Task<UserModels> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }
            return await _database.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task UpdateUserAsync(UserModels user)
        {
            _database.Users.Update(user);
            await _database.SaveChangesAsync();
        }
    }
}
