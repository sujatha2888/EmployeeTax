using Imaginnovate_Screening_Test.Models;
using Imaginnovate_Screening_Test.Services;
using Microsoft.AspNetCore.Mvc;

namespace Imaginnovate_Screening_Test.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeTaxController
    {
        private readonly IEmployeeTaxService _employeeTaxService;

        public EmployeeTaxController(IEmployeeTaxService employeeTaxService)
        {
            _employeeTaxService = employeeTaxService;
        }

        [HttpGet( "CalculateTax")]
        public List<EmployeeTaxDto> CalculateTax()
        {
            return _employeeTaxService.GetEmployeesTax();
        }
    }
}