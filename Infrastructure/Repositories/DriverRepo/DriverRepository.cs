using System;
using Domain.Models.Driver;
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

        public DriverModel GetDriverById(Guid id)
        {
            return _database.Drivers.FirstOrDefault(d => d.DriverId == id);
        }

        public void AddDriver(DriverModel driver)
        {
            _database.Drivers.Add(driver);
            _database.SaveChanges();
        }

        public void UpdateDriver(DriverModel driver)
        {
            _database.Drivers.Update(driver);
            _database.SaveChanges();
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

