using Domain.Models.Employee;
using MediatR;

namespace Application.Commands.Employee.AddEmployee
{
    public class AddEmployeeCommandHandler : IRequestHandler<AddEmployeeCommand, EmployeeModel>
    {
        public async Task<EmployeeModel> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                EmployeeModel employeeToCreate = new()
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = request.NewEmployee.FirstName,
                    LastName = request.NewEmployee.LastName,
                    Email = request.NewEmployee.Email,
                    Role = request.NewEmployee.Role,
                    Password = request.NewEmployee.Password,
                };
                return employeeToCreate;
            }
            catch (Exception ex)
            {
                var newException = new Exception($"An error occurred while adding a new employee: {ex.Message}", ex);
                throw newException;
            }
        }
    }
}