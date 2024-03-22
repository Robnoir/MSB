using System;
using Application.Dto.Driver;
using Application.Dto.Employee;
using Infrastructure.Repositories.DriverRepo;
using MediatR;

namespace Application.Queries.Driver.GetAll
{
    public class GetAllDriversQueryHandler
    {
        private readonly IDriverRepository _driverRepository;

        public GetAllDriversQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public IEnumerable<DriverDetailDto> Handle(GetAllDriversQuery query)
        {
            var drivers = _driverRepository.GetAllDrivers();

            var driverDtos = drivers.Select(driver => new DriverDetailDto
            {
                DriverId = driver.DriverId,
                EmployeeId = driver.EmployeeId,
                Employee = new EmployeeDto
                {
                    EmployeeId = driver.Employee.EmployeeId,
                    Email = driver.Employee.Email,
                    Password = driver.Employee.Password,
                    FirstName = driver.Employee.FirstName,
                    LastName = driver.Employee.LastName,
                    Role = driver.Employee.Role
                },
            });

            return driverDtos;
        }
    }
}

