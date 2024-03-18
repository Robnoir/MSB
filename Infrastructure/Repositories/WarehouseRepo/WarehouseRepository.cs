using Domain.Models.Warehouse;
using Infrastructure.Database;

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

    }
}
