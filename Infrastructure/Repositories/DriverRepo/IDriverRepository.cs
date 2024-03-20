using System;
using Domain.Models.Driver;

namespace Infrastructure.Repositories.DriverRepo
{
	public interface IDriverRepository
	{
        IEnumerable<DriverModel> GetAllDrivers();
        DriverModel GetDriverById(Guid id);
        void AddDriver(DriverModel driver);
        void UpdateDriver(DriverModel driver);
        void DeleteDriver(Guid id);
    }
}

