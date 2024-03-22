using System;
using Infrastructure.Repositories.CarRepo;

namespace Application.Commands.Car.UpdateCar
{
    public class UpdateCarCommandHandler
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(UpdateCarCommand command)
        {
            var existingCar = await _carRepository.GetCarById(command.CarId);
            if (existingCar != null)
            {
                existingCar.Volume = command.UpdatedCar.Volume;
                existingCar.Type = command.UpdatedCar.Type;
                existingCar.Availability = command.UpdatedCar.Availability;

                await _carRepository.UpdateCar(existingCar);
            }
        }
    }
}

