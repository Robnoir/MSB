using System;
using Domain.Models.Employee;
using MediatR;

namespace Application.Queries.Employee.GetById
{
    public class GetEmployeeByIdQuery : IRequest<EmployeeModel>
    {
        public GetEmployeeByIdQuery(Guid employeeId)
        {

            Id = employeeId;
        }

        public Guid Id { get; }
    }
}

