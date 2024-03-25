using Application.Dto.Car;
using Domain.Models.Car;
using Infrastructure.Repositories.CarRepo;

namespace Application.Commands.Car.AddCar
{
    public class AddCarCommandHandler
    {
        private readonly ICarRepository _carRepository;
        public AddCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(AddCarCommand command)
        {
            var carModel = MapToCarModel(command.Car);
            await _carRepository.AddCar(carModel);
        }
        private CarModel MapToCarModel(CarDto carDto)
        {
            return new CarModel
            {
                CarID = carDto.CarId,
                Volume = carDto.Volume,
                Type = carDto.Type,
                Availability = carDto.Availability,
            };
        }
    }
}