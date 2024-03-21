using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto.Car;
using Application.Dto.Driver;
using Domain.Models.Car;
using Domain.Models.Driver;
using Infrastructure.Repositories.DriverRepo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers.Car
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IDriverRepository _driverRepository;

        public CarController(ICarRepository carRepository, IDriverRepository driverRepository)
        {
            _carRepository = carRepository;
            _driverRepository = driverRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carModel = MapToCarModel(carDto);
            await _carRepository.AddCar(carModel);
            return Ok(carModel);
        }

        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteCar(Guid carId)
        {
            var existingCar = await _carRepository.GetCarById(carId);
            if (existingCar == null)
            {
                return NotFound();
            }

            await _carRepository.DeleteCar(carId);
            return NoContent();
        }

        [HttpPost("{carId}/drivers")]
        public async Task<IActionResult> AddDriverToCar(Guid carId, [FromBody] DriverDto driverDto)
        {
            var car = await _carRepository.GetCarById(carId);
            if (car == null)
            {
                return NotFound();
            }

            var driverModel = MapToDriverModel(driverDto);

            car.Driver = driverModel;
            await _carRepository.UpdateCar(car);

            return Ok(car);
        }

        [HttpDelete("{carId}/drivers")]
        public async Task<IActionResult> DeleteDriverFromCar(Guid carId)
        {
            var car = await _carRepository.GetCarById(carId);
            if (car == null || car.Driver == null)
            {
                return NotFound();
            }

            car.Driver = null;
            await _carRepository.UpdateCar(car);

            return NoContent();
        }

        [HttpPut("{carId}/drivers")]
        public async Task<IActionResult> ChangeDriverForCar(Guid carId, [FromBody] DriverDto driverDto)
        {
            var car = await _carRepository.GetCarById(carId);
            if (car == null)
            {
                return NotFound();
            }

            // Assuming you have a method to map DriverDto to DriverModel
            var driverModel = MapToDriverModel(driverDto);

            car.Driver = driverModel;
            await _carRepository.UpdateCar(car);

            return Ok(car);
        }

        private CarModel MapToCarModel(CarDto carDto)
        {
            return new CarModel
            {
                CarID = carDto.CarId,
                Volume = carDto.Volume,
                Type = carDto.Type,
                Availability = carDto.Availability,
                
            };
        }

        private DriverModel MapToDriverModel(DriverDto driverDto)
        {
            return new DriverModel
            {
                DriverID = driverDto.DriverId,
                EmployeeID = driverDto.EmployeeId,
                
            };
        }
    }
}

