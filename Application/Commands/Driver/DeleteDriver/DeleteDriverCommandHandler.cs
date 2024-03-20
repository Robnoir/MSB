using System;
using Infrastructure.Repositories.DriverRepo;

namespace Application.Commands.Driver.DeleteDriver
{
    public class DeleteDriverCommandHandler
    {
        private readonly IDriverRepository _driverRepository;

        public DeleteDriverCommandHandler(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task Handle(DeleteDriverCommand command)
        {
            _driverRepository.DeleteDriver(command.DriverId);
        }
    }
}

