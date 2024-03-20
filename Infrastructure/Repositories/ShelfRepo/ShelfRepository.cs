using Domain.Models.Shelf;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.ShelfRepo
{
    public class ShelfRepository : IShelfRepository
    {
        private readonly MSB_Database _msbDatabase;
        public ShelfRepository(MSB_Database msbDatabase)
        {
            _msbDatabase = msbDatabase;
        }

        public async Task<ShelfModel> AddShelfAsync(ShelfModel shelfToCreate)
        {
            _msbDatabase.Shelves.Add(shelfToCreate);
            await _msbDatabase.SaveChangesAsync();
            return shelfToCreate;
        }

        public async Task DeleteShelfAsync(Guid shelfId)
        {
            var shelf = await _msbDatabase.Shelves.FindAsync(shelfId);
            if (shelf != null)
            {
                _msbDatabase.Shelves.Remove(shelf);
                await _msbDatabase.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ShelfModel>> GetAllAsync()
        {
            return await _msbDatabase.Shelves.ToListAsync();
        }

        public async Task<ShelfModel> GetShelfByIdAsync(Guid shelfId)
        {
            return await _msbDatabase.Shelves.FindAsync(shelfId);
        }

        public async Task<ShelfModel> UpdateShelfAsync(ShelfModel shelfToUpdate)
        {
            _msbDatabase.Entry(shelfToUpdate).State = EntityState.Modified;
            await _msbDatabase.SaveChangesAsync();
            return shelfToUpdate;
        }
    }
}
