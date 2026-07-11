using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using EmployeeApi.Models;
using System;

namespace EmployeeApi.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // A STATIC list acts as our temporary database so updates persist
        private static List<Employee> _employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Alice", Salary = 85000, Permanent = true, Department = new Department { Id = 101, Name = "IT" }, Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" } }, DateOfBirth = new DateTime(1995, 5, 20) },
            new Employee { Id = 2, Name = "Bob", Salary = 60000, Permanent = false, Department = new Department { Id = 102, Name = "HR" }, Skills = new List<Skill> { new Skill { Id = 2, Name = "Communication" } }, DateOfBirth = new DateTime(1998, 1, 15) }
        };

        // HTTP GET Action Method
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(_employees);
        }

        // HTTP PUT Action Method
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)] // Documents the BadRequest
        public ActionResult<Employee> Put(int id, [FromBody] Employee updatedEmployee)
        {
            // Requirement 1: Check if id is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            // Find the employee in our hardcoded static list
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);

            // Requirement 2: Check if id exists in the list
            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Requirement 3: Update the hardcoded list with JSON data from input body
            existingEmployee.Name = updatedEmployee.Name;
            existingEmployee.Salary = updatedEmployee.Salary;
            existingEmployee.Permanent = updatedEmployee.Permanent;
            existingEmployee.Department = updatedEmployee.Department;
            existingEmployee.Skills = updatedEmployee.Skills;
            existingEmployee.DateOfBirth = updatedEmployee.DateOfBirth;

            // Requirement 4: Return the updated output
            return Ok(existingEmployee);
        }

        // HTTP POST Action Method (CREATE)
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Post([FromBody] Employee newEmployee)
        {
            if (newEmployee == null)
            {
                return BadRequest("Invalid employee data");
            }

            // Auto-generate a new ID based on the highest existing ID
            int newId = _employees.Any() ? _employees.Max(e => e.Id) + 1 : 1;
            newEmployee.Id = newId;

            // Add to our static list
            _employees.Add(newEmployee);

            return Ok(newEmployee);
        }

        // HTTP DELETE Action Method (DELETE)
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<Employee> Delete(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid employee id");
            }

            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);

            if (existingEmployee == null)
            {
                return BadRequest("Invalid employee id");
            }

            // Remove from our static list
            _employees.Remove(existingEmployee);

            return Ok(existingEmployee);
        }
    }
}