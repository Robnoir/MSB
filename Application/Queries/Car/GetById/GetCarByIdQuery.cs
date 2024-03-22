using System;
namespace Application.Queries.Car.GetById
{
	public class GetCarByIdQuery
	{
        public Guid CarId { get; }

        public GetCarByIdQuery(Guid carId)
        {
            CarId = carId;
        }
    }
}

