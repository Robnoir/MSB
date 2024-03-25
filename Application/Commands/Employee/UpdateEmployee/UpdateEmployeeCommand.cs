using Application.Dto.Employee;
using Domain.Models.Employee;
using MediatR;

namespace Application.Commands.Employee.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest<EmployeeModel>
    {
        public EmployeeDto UpdateEmployeeDto { get; }
        public Guid EmployeeId { get; }
        public string UpdatePassword { get; set; }
        public UpdateEmployeeCommand(EmployeeDto employeeDto, Guid employeeId)
        {
            UpdateEmployeeDto = employeeDto;
            EmployeeId = employeeId;
        }
    }
}