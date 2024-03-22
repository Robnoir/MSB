using Domain.Models.Employee;
using Infrastructure.Repositories.EmployeeRepo;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Employee
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/Employee
        [HttpGet]
        [Route("Get All Employees")]
        public async Task<ActionResult<IEnumerable<EmployeeModel>>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployeesAsync();
            return Ok(employees);
        }

        // GET: api/Employee/{id}
        [HttpGet("Get Employee By {id}")]
        public async Task<ActionResult<EmployeeModel>> GetEmployee(Guid id)
        {
            var employee = await _employeeRepository.GetEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        [Route("Add Employee")]
        public async Task<ActionResult<EmployeeModel>> CreateEmployee(EmployeeModel employee)
        {
            var createdEmployee = await _employeeRepository.CreateEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployee), new { id = createdEmployee.EmployeeId }, createdEmployee);
        }

        // PUT: api/Employee/{id}
        [HttpPut("Update Employee By {id}")]
        public async Task<IActionResult> UpdateEmployee(Guid id, EmployeeModel employee)
        {
            var updatedEmployee = await _employeeRepository.UpdateEmployeeAsync(id, employee);
            if (updatedEmployee == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE: api/Employee/{id}
        [HttpDelete("Delete Employee By {id}")]
        public async Task<IActionResult> DeleteEmployee(Guid id)
        {
            var result = await _employeeRepository.DeleteEmployeeAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
