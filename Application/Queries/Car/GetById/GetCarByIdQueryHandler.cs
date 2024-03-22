using System;
using Domain.Models.Car;
using Infrastructure.Database;
using Infrastructure.Repositories.CarRepo;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Car.GetById
{
    public class GetCarByIdQueryHandler
    {
        private readonly MSB_Database _database;
        private readonly ICarRepository _carRepository;

        public GetCarByIdQueryHandler(ICarRepository carRepository, MSB_Database database)
        {
            _carRepository = carRepository;
            _database = database;
        }

        public async Task<CarModel> Handle(GetCarByIdQuery query)
        {
            return await _database.Cars.FindAsync(query.CarId);
        }
    }
}

