using System;
using Domain.Models.Car;
using Infrastructure.Database;
using Infrastructure.Repositories.CarRepo;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Car
{
    public class GetAllCarsQueryHandler
    {
        
        private readonly MSB_Database _database;

        public GetAllCarsQueryHandler(MSB_Database database)
        {
            _database = database;
        }

        public async Task<List<CarModel>> Handle(GetAllCarsQuery query)
        {
            return await _database.Cars.ToListAsync();
        }
    }
}

