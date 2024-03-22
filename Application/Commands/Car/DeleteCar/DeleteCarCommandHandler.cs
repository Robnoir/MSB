using Infrastructure.Repositories.CarRepo;

namespace Application.Commands.Car.DeleteCar
{
    public class DeleteCarCommandHandler
    {
        private readonly ICarRepository _carRepository;
        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task Handle(DeleteCarCommand command)
        {
            var existingCar = await _carRepository.GetCarById(command.CarId);
            if (existingCar != null)
            {
                await _carRepository.DeleteCar(existingCar);
            }
        }
    }
}