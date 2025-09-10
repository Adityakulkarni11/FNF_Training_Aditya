using Microsoft.EntityFrameworkCore;
using WebAPIWithJWT.Models;
namespace WebAPIWithJWT.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);

    }

    public class EmployeeRepo : IEmployeeService
    {
        private readonly Data.AppDbContext _context;
        public EmployeeRepo(Data.AppDbContext context)
        {
            _context = context;
        }
        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }
        public async Task<Employee> UpdateEmployeeAsync(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if (existingEmployee != null)
            {
                existingEmployee.EmpName = employee.EmpName;
                existingEmployee.EmpDepartment = employee.EmpDepartment;
                existingEmployee.EmpSalary = employee.EmpSalary;
                existingEmployee.DateOfBirth = employee.DateOfBirth;
                await _context.SaveChangesAsync();
            }
            return existingEmployee;
        }
    }
}
