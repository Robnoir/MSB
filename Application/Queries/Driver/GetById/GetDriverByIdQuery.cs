using System;
namespace Application.Queries.Driver.GetById
{
    public class GetDriverByIdQuery
    {
        public Guid DriverId { get; }

        public GetDriverByIdQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }
}

