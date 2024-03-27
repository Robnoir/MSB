using System;
using Domain.Models.Car;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.CarRepo
{
    public class CarRepository : ICarRepository
    {
        private readonly MSB_Database _database;

        public CarRepository(MSB_Database database)
        {
            _database = database;
        }

        public async Task AddCar(CarModel carModel)
        {
            await _database.Cars.AddAsync(carModel);
            await _database.SaveChangesAsync();
        }

        public async Task<IEnumerable<CarModel>> GetAllCars()
        {
            return await _database.Cars.Include(c => c.Drivers).ToListAsync();
        }

        public async Task<CarModel> GetCarById(Guid carId)
        {
            return await _database.Cars.Include(c => c.Drivers).FirstOrDefaultAsync(c => c.CarId == carId);
        }

        public async Task UpdateCar(CarModel car)
        {
            _database.Cars.Update(car);
            await _database.SaveChangesAsync();
        }

        public async Task DeleteCar(CarModel car)
        {
            _database.Cars.Remove(car);
            await _database.SaveChangesAsync();
        }
    }

}

