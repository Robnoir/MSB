using Domain.Models.Driver;

namespace Application.Commands.Driver.UpdateDriver
{
    public class UpdateDriverCommand
    {
        public Guid DriverId { get; set; }
        public DriverModel UpdatedDriver { get; set; }
    }
}