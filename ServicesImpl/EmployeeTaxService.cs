using Imaginnovate_Screening_Test.Models;
using Imaginnovate_Screening_Test.Utils;

namespace Imaginnovate_Screening_Test.Services
{
    public class EmployeeTaxService : IEmployeeTaxService
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeTaxService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public List<EmployeeTaxDto> GetEmployeesTax()
        {
            List<EmployeeDto> employees = _employeeService.GetAllEmployees();
            List<EmployeeTaxDto> employeesTaxDto = new List<EmployeeTaxDto>();
            foreach (EmployeeDto employeeDto in employees)
            {
                EmployeeTaxDto employeeTaxDto = GetEmployeeTax(employeeDto);
                employeesTaxDto.Add(employeeTaxDto);
            }
            return employeesTaxDto;
        }

        public EmployeeTaxDto GetEmployeeTax(EmployeeDto employeeDto)
        {
            EmployeeTaxDto employeeTaxDto = new EmployeeTaxDto();
            employeeTaxDto.EmployeeID = employeeDto.EmployeeID;
            employeeTaxDto.FirstName = employeeDto.FirstName;
            employeeTaxDto.LastName = employeeDto.LastName;
            employeeTaxDto.Doj = employeeDto.DOJ;
            employeeTaxDto.SalaryYearly = EmployeeUtils.getTotalSalary(employeeDto.DOJ, employeeDto.Salary, 0);
            employeeTaxDto.TaxAmount = EmployeeUtils.getTax(employeeTaxDto.SalaryYearly);
            employeeTaxDto.CessAmount = EmployeeUtils.getCess(employeeTaxDto.SalaryYearly);
            return employeeTaxDto;
        }
    }
}
