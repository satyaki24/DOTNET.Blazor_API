using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.DataModel;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>();

        [HttpGet]
        [Route("GetAllEmployees")]

        public IActionResult GetAllEmployees()
        {
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteAllEmployees")]
        public IActionResult DeleteAllEmployees()
        {
            employees.Clear();
            return Ok("All employees have been deleted.");
        }

        [HttpDelete]
        [Route("DeleteEmployeeById/{id}")]
        public IActionResult DeleteEmployeeById(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            employees.Remove(employee);
            return Ok($"Employee with ID {id} has been deleted.");
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee([FromBody] Employee newEmployee)
        {
            if (newEmployee == null)
                return BadRequest("Employee data is null.");

            int nextId = employees.Any() ? employees.Max(e => e.Id) + 1 : 1;
            newEmployee.Id = nextId;

            employees.Add(newEmployee);
            return Ok($"Employee with ID {newEmployee.Id} added successfully.");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public IActionResult UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            var existingEmployee = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {updatedEmployee.Id} not found.");

            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Age = updatedEmployee.Age;
            existingEmployee.Department = updatedEmployee.Department;

            return Ok($"Employee with ID {updatedEmployee.Id} updated successfully.");
        }

    }
}
