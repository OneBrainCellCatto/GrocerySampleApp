using Grocery.Models;

namespace Grocery.Services.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IReadOnlyList<Employee>> GetEmployees(int? civilStatusFilter = null, int? positionFilter = null, string? searchString = null, bool IsEmployed = true);
        Task<Employee> GetEmployee(int id);
        void AddEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);
        Task<bool> SaveChangesAsync();
    }
}
