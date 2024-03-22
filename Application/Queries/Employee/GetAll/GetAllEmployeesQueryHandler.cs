using System;
using Domain.Models.Employee;
using Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries.Employee.GetAll
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, List<EmployeeModel>>
    {
        private readonly MSB_Database _database;

        public GetAllEmployeesQueryHandler(MSB_Database database)
        {
            _database = database;
        }

        public async Task<List<EmployeeModel>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken)
        {
            return await _database.Employees.ToListAsync();
        }
    }
}

