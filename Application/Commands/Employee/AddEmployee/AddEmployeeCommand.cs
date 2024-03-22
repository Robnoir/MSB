using Application.Dto.Employee;
using Domain.Models.Employee;
using MediatR;

namespace Application.Commands.Employee.AddEmployee
{
    public class AddEmployeeCommand : IRequest<EmployeeModel>
    {
        public AddEmployeeCommand(EmployeeDto newEmployee)
        {
            NewEmployee = newEmployee;
        }
        public EmployeeDto NewEmployee { get; }
    }
}