using Project.DataModel;
using System.Net;

namespace Project.UI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;
        public EmployeeService(HttpClient _httpClient)
        {
            this.httpClient = _httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAllEmployees()
        {
            return await httpClient.GetFromJsonAsync<Employee[]>("api/Employee/GetAllEmployees");
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            var response = await httpClient.GetAsync($"api/Employee/GetEmployeeById/{id}");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<Employee>();

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            throw new Exception("Server error while fetching employee.");
        }

        public async Task<string> AddEmployee(Employee employee)
        {
            var response = await httpClient.PostAsJsonAsync("api/Employee/AddEmployee", employee);
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteEmployeeById(int id)
        {
            var response = await httpClient.DeleteAsync($"api/Employee/DeleteEmployeeById/{id}");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> DeleteAllEmployees()
        {
            var response = await httpClient.DeleteAsync("api/Employee/DeleteAllEmployees");
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> UpdateEmployee(Employee employee)
        {
            var response = await httpClient.PutAsJsonAsync("api/Employee/UpdateEmployee", employee);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
