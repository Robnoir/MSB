using Domain.Models.Employee;
using MediatR;

namespace Application.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<EmployeeModel>
    {
        public Guid EmployeeId { get; set; }
        public DeleteEmployeeCommand(Guid employeeId)
        {
            EmployeeId = employeeId;
        }
    }
}