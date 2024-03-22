using System;
using Domain.Models.Driver;
using Infrastructure.Repositories.DriverRepo;

namespace Application.Commands.Driver.AddDriver
{
    public class AddDriverCommandHandler
    {
        private readonly IDriverRepository _driverRepository;

        public AddDriverCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public void Handle(AddDriverCommand command)
        {
            var driver = new DriverModel
            {
                DriverId = command.DriverId,
                EmployeeId = command.EmployeeId,
                // Initialize other properties as needed
            };

            _driverRepository.AddDriver(driver);
        }
    }
}

