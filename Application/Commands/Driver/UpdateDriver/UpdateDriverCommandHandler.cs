using System;
using Infrastructure.Repositories.DriverRepo;

namespace Application.Commands.Driver.UpdateDriver
{
    public class UpdateDriverCommandHandler
    {
        private readonly IDriverRepository _driverRepository;

        public UpdateDriverCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task Handle(UpdateDriverCommand command)
        {
            _driverRepository.UpdateDriver(command.UpdatedDriver);
        }
    }
}

