using System;
using Domain.Models.Employee;
using Infrastructure.Repositories.EmployeeRepo;
using Infrastructure.Repositories.UserRepo;

namespace Application.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommandHandler
    {
        private readonly IEmployeeRepository _employeeRepository;
        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeModel> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetEmployeeByIdAsync(command.EmployeeId);
            if (employee == null)
            {
                throw new KeyNotFoundException("Employee not found");
            }

            employee.Email = command.UpdateEmployeeDto.Email ?? employee.Email;
            employee.FirstName = command.UpdateEmployeeDto.FirstName ?? employee.FirstName;
            employee.LastName = command.UpdateEmployeeDto.LastName ?? employee.LastName;


            await _employeeRepository.UpdateEmployeeAsync(command.EmployeeId, employee);
            return employee;
        }
    }
}

