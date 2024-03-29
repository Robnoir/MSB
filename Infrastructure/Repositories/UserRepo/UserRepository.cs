﻿using Domain.Models.User;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

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
            await _database.Users.AddAsync(user);
            await _database.SaveChangesAsync();

            return await Task.FromResult(user);

        }

        public async Task DeleteUserAsync(Guid id)
        {
            var DeleteUserId = await _database.Users.FindAsync(id);
            if (DeleteUserId != null)
            {
                _database.Users.Remove(DeleteUserId);
                await _database.SaveChangesAsync();
            }
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _database.Users.Include(u => u.Addresses).ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(Guid id)
        {
            return await _database.Users.FindAsync(id);
        }

        public async Task<UserModel> GetByEmailAsync(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email cannot be null or empty", nameof(email));
            }
            return await _database.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }

        public async Task UpdateUserAsync(UserModel user)
        {
            _database.Users.Update(user);
            await _database.SaveChangesAsync();
        }

        public async Task<bool> UpdatePasswordAsync(UserModel user)
        {
            var userEntity = await _database.Users.FindAsync(user.UserId);
            if (userEntity == null)
            {
                return false; // User not found, return false
            }

            userEntity.PasswordHash = user.PasswordHash; // Assume new password hash has already been set
            await _database.SaveChangesAsync();
            return true; // Password update successful
        }
    }
}
