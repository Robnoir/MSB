using System;
using Application.Dto.Driver;
using Application.Dto.Employee;
using Application.Dto.Item;
using Application.Queries.Driver.GetAll;
using Infrastructure.Repositories.DriverRepo;
using Infrastructure.Repositories.EmployeeRepo;
using MediatR;

namespace Application.Queries.Driver.GetById
{
    public class GetDriverByIdQueryHandler
    {
        private readonly IDriverRepository _driverRepository;

        public GetDriverByIdQueryHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public DriverDetailDto Handle(GetDriverByIdQuery query)
        {
            var driver = _driverRepository.GetDriverById(query.DriverId);

            if (driver == null)
            {
                return null;
            }

            return new DriverDetailDto
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
                
            };
        }
    }
}
