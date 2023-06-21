using Imaginnovate_Screening_Test.Models;
using Imaginnovate_Screening_Test.Services;
using Imaginnovate_Screening_Test.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Imaginnovate_Screening_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
           _employeeService = employeeService;
        }

        [HttpPost( "Post")]
        public Employee AddEmployee(Employee employee)
        {
            return _employeeService.Save(employee);
        }

        [HttpGet("Get")]
        public List<EmployeeDto> GetEmployee()
        {
            return _employeeService.GetAllEmployees();
        }
    }
}