using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.API.Data;
using Project.DataModel;

namespace Project.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAllEmployees")]

        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");
            return Ok(employee);
        }

        [HttpDelete]
        [Route("DeleteAllEmployees")]
        public async Task<IActionResult> DeleteAllEmployees()
        {
            var allEmployees = await _context.Employees.ToListAsync();
            _context.Employees.RemoveRange(allEmployees);
            await _context.SaveChangesAsync();
            return Ok("All employees have been deleted.");
        }

        [HttpDelete]
        [Route("DeleteEmployeeById/{id}")]
        public async Task<IActionResult> DeleteEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
                return NotFound($"Employee with ID {id} not found.");

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok($"Employee with ID {id} has been deleted.");
        }

        [HttpPost]
        [Route("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] Employee newEmployee)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Employees.Add(newEmployee);
            await _context.SaveChangesAsync();
            return Ok($"Employee with ID {newEmployee.Id} added successfully.");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee updatedEmployee)
        {
            var existingEmployee = await _context.Employees.FindAsync(updatedEmployee.Id);
            if (existingEmployee == null)
                return NotFound($"Employee with ID {updatedEmployee.Id} not found.");

            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Email = updatedEmployee.Email;
            existingEmployee.Age = updatedEmployee.Age;
            existingEmployee.Department = updatedEmployee.Department;

            await _context.SaveChangesAsync();
            return Ok($"Employee with ID {updatedEmployee.Id} updated successfully.");
        }

    }
}
