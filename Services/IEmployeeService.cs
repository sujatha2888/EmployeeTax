using Imaginnovate_Screening_Test.Models;

namespace Imaginnovate_Screening_Test.Services
{
    public interface IEmployeeService
    {
        public Employee Save(Employee employee);
        public List<EmployeeDto> GetAllEmployees();
        
    }
}
