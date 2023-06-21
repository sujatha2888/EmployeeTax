using Imaginnovate_Screening_Test.Models;

namespace Imaginnovate_Screening_Test.Services
{
    public interface IEmployeeTaxService
    {
        public List<EmployeeTaxDto> GetEmployeesTax();
        public EmployeeTaxDto GetEmployeeTax(EmployeeDto employeeDto);
    }
}
