using System;
using Domain.Models.Employee;
using MediatR;

namespace Application.Queries.Employee.GetAll
{
    public class GetAllEmployeesQuery : IRequest<List<EmployeeModel>>
    {

    }
}

