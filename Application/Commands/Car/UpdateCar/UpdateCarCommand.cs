using Application.Dto.Car;

namespace Application.Commands.Car.UpdateCar
{
    public class UpdateCarCommand
    {
        public Guid CarId { get; }
        public CarDto UpdatedCar { get; }
        public UpdateCarCommand(Guid carId, CarDto updatedCar)
        {
            CarId = carId;
            UpdatedCar = updatedCar;
        }
    }
}