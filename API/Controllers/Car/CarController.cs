using Application.Commands.Car.AddCar;
using Application.Commands.Car.DeleteCar;
using Application.Commands.Car.UpdateCar;
using Application.Dto.Car;
using Application.Dto.Driver;
using Application.Queries.Car;
using Application.Queries.Car.GetById;
using Domain.Models.Car;
using Domain.Models.Driver;
using Infrastructure.Repositories.CarRepo;
using Infrastructure.Repositories.DriverRepo;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers.Car
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarRepository _carRepository;
        private readonly IDriverRepository _driverRepository;
        private readonly GetAllCarsQueryHandler _getAllCarsQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly AddCarCommandHandler _addCarCommandHandler;
        private readonly DeleteCarCommandHandler _deleteCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;


        public CarController(ICarRepository carRepository, IDriverRepository driverRepository, GetAllCarsQueryHandler getAllCarsQueryHandler, GetCarByIdQueryHandler getCarByIdQueryHandler, AddCarCommandHandler addCarCommandHandler, DeleteCarCommandHandler deleteCarCommandHandler, UpdateCarCommandHandler updateCarCommandHandler)
        {
            _carRepository = carRepository;
            _driverRepository = driverRepository;
            _getAllCarsQueryHandler = getAllCarsQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _addCarCommandHandler = addCarCommandHandler;
            _deleteCarCommandHandler = deleteCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;

        }

        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarById(Guid carId)
        {
            var query = new GetCarByIdQuery(carId);
            var car = await _getCarByIdQueryHandler.Handle(query);
            if (car == null)
            {
                return NotFound();
            }
            return Ok(car);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            var query = new GetAllCarsQuery();
            var cars = await _getAllCarsQueryHandler.Handle(query);
            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarDto carDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command = new AddCarCommand(carDto);
            await _addCarCommandHandler.Handle(command);
            return Ok(carDto);
        }

        [HttpPut("{carId}")]
        public async Task<IActionResult> UpdateCar(Guid carId, [FromBody] CarDto carDto)
        {
            var command = new UpdateCarCommand(carId, carDto);
            await _updateCarCommandHandler.Handle(command);
            return NoContent();
        }


        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteCar(Guid carId)
        {
            var command = new DeleteCarCommand(carId);
            await _deleteCarCommandHandler.Handle(command);
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
                DriverId = driverDto.DriverId,
                EmployeeId = driverDto.EmployeeId,

            };
        }
    }
}

