using Application.Dto.Driver;
using Application.Dto.Employee;
using Application.Queries.Driver.GetAll;
using Domain.Models.Driver;
using Infrastructure.Repositories.DriverRepo;
using Microsoft.AspNetCore.Mvc;
using Application.Dto.Car;

namespace API.Controllers.Driver
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;

        public DriversController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }
        private readonly GetAllDriversQueryHandler _getAllDriversQueryHandler;

        public DriversController(GetAllDriversQueryHandler getAllDriversQueryHandler)
        {
            _getAllDriversQueryHandler = getAllDriversQueryHandler;
        }

        // GET: api/Drivers
        [HttpGet]
        public ActionResult<IEnumerable<DriverDetailDto>> GetDrivers()
        {
            var drivers = _driverRepository.GetAllDrivers();

            var driverDtos = drivers.Select(driver => new DriverDetailDto
            {
                DriverId = driver.DriverId,
                EmployeeId = driver.EmployeeId,
                CarId = driver.CarId,
                Employee = new EmployeeDto
                {
                    EmployeeId = driver.Employee.EmployeeId,
                    Email = driver.Employee.Email,
                    Password = driver.Employee.Password,
                    FirstName = driver.Employee.FirstName,
                    LastName = driver.Employee.LastName,
                    Role = driver.Employee.Role
                },
                Car = new CarDto
                {
                    CarId = driver.Car.CarId
                }

            });

            return Ok(driverDtos);
        }

        // POST: api/Drivers
        [HttpPost]
        public ActionResult<DriverDetailDto> PostDriver(DriverDto driverDto)
        {
            var driver = new DriverModel
            {
                DriverId = driverDto.DriverId,
                EmployeeId = driverDto.EmployeeId,
                CarId = driverDto.CarId
            };

            _driverRepository.AddDriver(driver);

            return Ok(driverDto);
        }

        // PUT: api/Drivers/5
        [HttpPut("{id}")]
        public IActionResult PutDriver(Guid id, DriverDto driverDto)
        {
            if (id != driverDto.DriverId)
            {
                return BadRequest();
            }

            var driver = new DriverModel
            {
                DriverId = driverDto.DriverId,
                EmployeeId = driverDto.EmployeeId,
                CarId = driverDto.CarId
            };

            _driverRepository.UpdateDriver(driver);

            return NoContent();
        }

        // DELETE: api/Drivers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DriverDto>> DeleteDriver(Guid id)
        {
            var driver = await _driverRepository.GetDriverByIdAsync(id);
            if (driver == null)
            {
                return NotFound();
            }

            _driverRepository.DeleteDriver(id);

            // You can return the deleted driver DTO if needed
            return Ok(new DriverDto
            {
                DriverId = driver.DriverId,
                EmployeeId = driver.EmployeeId,
                CarId = driver.CarId
            });
        }

    }
}