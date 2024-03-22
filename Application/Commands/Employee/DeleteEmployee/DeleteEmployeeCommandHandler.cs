using System;
using Domain.Models.Employee;
using Infrastructure.Repositories.EmployeeRepo;
using Infrastructure.Repositories.UserRepo;
using MediatR;

namespace Application.Commands.Employee.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, EmployeeModel>
    {

        private readonly IEmployeeRepository _employeeRepository;
        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;

        }
        public async Task<EmployeeModel> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                EmployeeModel employeeToDelete = await _employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);

                if (employeeToDelete == null)
                {
                    throw new InvalidOperationException("No Employee with the given id was found");
                }

                await _employeeRepository.DeleteEmployeeAsync(request.EmployeeId);

                return employeeToDelete;

            }
            catch (Exception ex)
            {
                var newException = new Exception($"An Error occurred when deleteting employee with id {request.EmployeeId}", ex);
                throw newException;
            }


        }
    }
}

