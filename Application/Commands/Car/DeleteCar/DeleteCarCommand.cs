namespace Application.Commands.Car.DeleteCar
{
    public class DeleteCarCommand
    {
        public Guid CarId { get; }
        public DeleteCarCommand(Guid carId)
        {
            CarId = carId;
        }
    }
}