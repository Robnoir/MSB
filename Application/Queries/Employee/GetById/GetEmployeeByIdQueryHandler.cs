using System;
using Domain.Models.Employee;
using Infrastructure.Repositories.EmployeeRepo;
using MediatR;

namespace Application.Queries.Employee.GetById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeModel>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeModel> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var employeeId = request.Id;
                var employee = await _employeeRepository.GetEmployeeByIdAsync(employeeId);
                return employee;
            }
            catch (Exception ex)
            {
                // Handle exceptions accordingly
                throw new Exception("Error occurred while fetching employee by ID", ex);
            }
        }
    }
}

