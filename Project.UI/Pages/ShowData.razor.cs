using Microsoft.AspNetCore.Components;
using Project.DataModel;

namespace Project.UI.Pages
{
    public partial class ShowData : ComponentBase
    {
        private IEnumerable<Employee>? employees;
        private Employee newEmployee = new();
        private string? errorMessage;
        private string? addMessage;
        private string? deleteMessage;
        private string? searchMessage;

        private int deleteId;
        private int searchId;
        private Employee? searchedEmployee;

        protected override async Task OnInitializedAsync()
        {
            try
            {
                employees = await _EmployeeService.GetAllEmployees();
            }
            catch (Exception ex)
            {
                errorMessage = "An error occurred while loading employee data.";
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private async Task AddNewEmployee()
        {
            addMessage = await _EmployeeService.AddEmployee(newEmployee);
            newEmployee = new Employee();
            employees = await _EmployeeService.GetAllEmployees();
        }

        private async Task DeleteEmployeeById()
        {
            deleteMessage = await _EmployeeService.DeleteEmployeeById(deleteId);
            employees = await _EmployeeService.GetAllEmployees();
        }

        private async Task SearchEmployeeById()
        {
            searchedEmployee = null;
            searchMessage = string.Empty;

            try
            {
                var emp = await _EmployeeService.GetEmployeeById(searchId);

                if (emp != null)
                {
                    searchedEmployee = emp;
                }
                else
                {
                    searchMessage = $"No employee found with ID {searchId}.";
                }
            }
            catch (Exception ex)
            {
                searchMessage = $"Error: {ex.Message}";
                Console.WriteLine($"Exception during search: {ex}");
            }
        }


        private Employee? editEmployee;

        private void StartEdit(Employee emp)
        {
            editEmployee = new Employee
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Age = emp.Age,
                Department = emp.Department
            };
        }

        private void CancelEdit()
        {
            editEmployee = null;
        }

        private async Task SaveEditEmployee()
        {
            if (editEmployee != null)
            {
                var result = await _EmployeeService.UpdateEmployee(editEmployee);
                addMessage = result;
                editEmployee = null;
                employees = await _EmployeeService.GetAllEmployees(); // Refresh
            }
        }
    }
}
