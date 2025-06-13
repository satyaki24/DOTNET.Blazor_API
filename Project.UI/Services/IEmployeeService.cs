using Project.DataModel;

namespace Project.UI.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployees();
        Task<Employee?> GetEmployeeById(int id);
        Task<string> AddEmployee(Employee employee);
        Task<string> DeleteEmployeeById(int id);
        Task<string> DeleteAllEmployees();
        Task<string> UpdateEmployee(Employee employee);

    }
}
