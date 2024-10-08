using Grocery.Data;
using Grocery.Models;
using Grocery.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Grocery.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;
        
        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }
        public void AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public void DeleteEmployee(Employee employee)
        {
            _context.Employees.Remove(employee);
        }

        public async Task<Employee> GetEmployee(int id)
        {
            return await _context.Employees.FindAsync(id);
        }


        public async Task<IReadOnlyList<Employee>> GetEmployees(int? civilStatusFilter = null, int? positionFilter = null, string? searchString = null, bool IsEmployed = true)
        {
            var query = (from employees in _context.Employees
                        select employees);
            if (IsEmployed)
            {
                query = query.Where(x => x.CurrentlyEmployed == true);
            }

            if (civilStatusFilter is not null)
            {
                query = query.Where(x => x.CivilStatus.CivilStatusId == civilStatusFilter);
            }

            if(positionFilter is not null)
            {
                query = query.Where(x => x.Position.PositionId == positionFilter);
            }
            if(!String.IsNullOrEmpty(searchString))
            {
                var isNumeric = Int32.TryParse(searchString, out int employeeId);
                if(isNumeric)
                {
                    query = query.Where(x => x.EmployeeId == employeeId);
                }
                else
                {
                    query = query.Where(x => x.FirstName.Contains(searchString) || x.MiddleName.Contains(searchString) || x.LastName.Contains(searchString));
                }
            }


            return await query.Include(x => x.Gender).Include(x => x.Position).Include(x => x.CivilStatus).ToListAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void UpdateEmployee(Employee employee)
        {
            _context.Employees.Update(employee);
        }
    }
}
