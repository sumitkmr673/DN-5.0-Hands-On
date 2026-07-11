using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;
using System.Collections.Generic;

namespace EmployeeApi.Controllers
{
    [Route("api/Emp")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET api/employee
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Alice", "Bob", "Charlie" };
        }
    }
}