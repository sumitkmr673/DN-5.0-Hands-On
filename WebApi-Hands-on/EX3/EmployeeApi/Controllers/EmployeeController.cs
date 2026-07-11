using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using EmployeeApi.Models;
using System;
using EmployeeApi.Filters;

namespace EmployeeApi.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    [CustomAuthFilter]
    [CustomExceptionFilter]
    public class EmployeeController : ControllerBase
    {
        // 1. Private method returning the custom list
        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Alice",
                    Salary = 85000,
                    Permanent = true,
                    Department = new Department { Id = 101, Name = "IT" },
                    Skills = new List<Skill> { new Skill { Id = 1, Name = "C#" }, new Skill { Id = 2, Name = "SQL" } },
                    DateOfBirth = new DateTime(1995, 5, 20)
                }
            };
        }

        // 2. HTTP GET Action Method
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<Employee>> GetStandard()
        {
            throw new Exception("This is a forced crash for the exercise");
        }
    }
}