using Domain.Models.Warehouse;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.WarehouseRepo
{
    public class WarehouseRepository : IWarehouseRepository
    {
        private readonly MSB_Database _database;
        public WarehouseRepository(MSB_Database mSB_Database)
        {
            _database = mSB_Database;
        }

        public async Task<WarehouseModel> AddWarehouseAsync(WarehouseModel warehouse)
        {
            _database.Warehouses.AddAsync(warehouse);
            _database.SaveChangesAsync();

            return await Task.FromResult(warehouse);
        }
        public async Task<WarehouseModel> DeleteWarehouseAsync(Guid id)
        {
            var warehouse = await _database.Warehouses.FindAsync(id);
            if (warehouse != null)
            {
                _database.Warehouses.Remove(warehouse);
                await _database.SaveChangesAsync();
            }
            return warehouse;
        }

        public async Task<IEnumerable<WarehouseModel>> GetAllWarehousesAsync()
        {
            return await _database.Warehouses.ToListAsync();
        }

        public async Task<WarehouseModel> GetWarehouseByIdAsync(Guid id)
        {
            return await _database.Warehouses.FindAsync(id);
        }
        public async Task<WarehouseModel> UpdateWarehouseAsync(WarehouseModel warehouse)
        {
            _database.Entry(warehouse).State = EntityState.Modified;
            await _database.SaveChangesAsync();
            return warehouse;
        }
    }
}
