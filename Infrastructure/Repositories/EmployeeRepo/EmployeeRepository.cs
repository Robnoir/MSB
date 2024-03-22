using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Employee;


namespace Infrastructure.Repositories.EmployeeRepo
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MSB_Database _database;
        public EmployeeRepository(MSB_Database mSB_Database)
        {
            _database = mSB_Database;
        }

        public async Task<IEnumerable<EmployeeModel>> GetEmployeesAsync()
        {
            return await _database.Employees.ToListAsync();
        }

        public async Task<EmployeeModel> GetEmployeeAsync(Guid id)
        {
            return await _database.Employees.FindAsync(id);
        }

        public async Task<EmployeeModel> CreateEmployeeAsync(EmployeeModel employee)
        {
            _database.Employees.Add(employee);
            await _database.SaveChangesAsync();
            return employee;
        }

        public async Task<EmployeeModel> UpdateEmployeeAsync(Guid id, EmployeeModel employee)
        {
            var existingEmployee = await _database.Employees.FindAsync(id);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.FirstName = employee.FirstName;
            existingEmployee.LastName = employee.LastName;
            existingEmployee.Email = employee.Email;
            existingEmployee.Password = employee.Password;
            existingEmployee.Role = employee.Role;

            // Uppdatera resten av egenskaperna om det behövs

            await _database.SaveChangesAsync();

            return existingEmployee;
        }

        public async Task<bool> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _database.Employees.FindAsync(id);

            if (employee == null)
            {
                return false;
            }

            _database.Employees.Remove(employee);
            await _database.SaveChangesAsync();

            return true;
        }
        public async Task<EmployeeModel> GetEmployeeByIdAsync(Guid employeeId)
        {
            try
            {
                EmployeeModel employee = await _database.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while fetching employee by ID", ex);
            }
        }

    }
}
