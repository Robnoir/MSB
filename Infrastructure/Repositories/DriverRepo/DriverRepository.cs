using System;
using Domain.Models.Driver;
using Domain.Models.Order;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.DriverRepo
{
    public class DriverRepository : IDriverRepository
    {
        private readonly MSB_Database _database;

        public DriverRepository(MSB_Database database)
        {
            _database = database;
        }

        public IEnumerable<DriverModel> GetAllDrivers()
        {
            return _database.Drivers.ToList();
        }

        public async Task<DriverModel> GetDriverByIdAsync(Guid id)
        {
            return await _database.Drivers.FirstOrDefaultAsync(d => d.DriverId == id);
        }

        public void AddDriver(DriverModel driver)
        {
            _database.Drivers.Add(driver);
            _database.SaveChanges();
        }



        public async Task UpdateDriver(DriverModel driver)
        {
            _database.Drivers.Update(driver);
            await _database.SaveChangesAsync();
        }

        public void DeleteDriver(Guid id)
        {
            var driver = _database.Drivers.Find(id);
            if (driver == null)
                return;

            _database.Drivers.Remove(driver);
            _database.SaveChanges();
        }

     
      
    }
}

