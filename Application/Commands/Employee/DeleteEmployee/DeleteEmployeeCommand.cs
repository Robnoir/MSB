using System;
using Domain.Models.Employee;
using Domain.Models.EmployeeModel;
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

