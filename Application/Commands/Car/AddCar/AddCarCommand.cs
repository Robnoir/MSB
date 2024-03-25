using Application.Dto.Car;

namespace Application.Commands.Car.AddCar
{
    public class AddCarCommand
    {
        public CarDto Car { get; set; }
        public AddCarCommand(CarDto car)
        {
            Car = car;
        }
    }
}