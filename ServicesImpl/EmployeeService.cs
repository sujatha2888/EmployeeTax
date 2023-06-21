using Imaginnovate_Screening_Test.Models;
using Imaginnovate_Screening_Test.Utils;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace Imaginnovate_Screening_Test.Services
{
    public class EmployeeService : IEmployeeService
    {
        public Employee Save(Employee employee)
        {
            employee.EmployeeID = EmployeeUtils.RandomString();
            List<Employee> employees = EmployeeUtils.EmployeeData();
            employees.Add(employee);
            return employee;
        }


        public List<EmployeeDto> GetAllEmployees()
        {
            List<Employee> employees = EmployeeUtils.EmployeeData();
            List<EmployeeDto> employeesDto = new List<EmployeeDto>();
            foreach (Employee employee in employees)
            {
                EmployeeDto employeeDto = new EmployeeDto();
                employeeDto.Email = employee.Email;
                employeeDto.FirstName = employee.FirstName;
                employeeDto.LastName = employee.LastName;
                employeeDto.Salary = employee.Salary;
                employeeDto.DOJ = employee.DOJ;
                employeeDto.EmployeeID = employee.EmployeeID;
                employeeDto.PhoneNumber = employee.PhoneNumber;
                employeesDto.Add(employeeDto);
            }
            return employeesDto;
        }

        public EmployeeDto GetEmployee(string employeeID)
        {
            List<Employee> employees = EmployeeUtils.EmployeeData();
            EmployeeDto employeeDto = new EmployeeDto();
            foreach (Employee employee in employees)
            {
                if (employee.EmployeeID == employeeID)
                {
                    employeeDto.Email = employee.Email;
                    employeeDto.FirstName = employee.FirstName;
                    employeeDto.LastName = employee.LastName;
                    employeeDto.Salary = employee.Salary;
                    employeeDto.Email = employee.Email;
                    employeeDto.DOJ = employee.DOJ;
                    break;
                }
            }
            return employeeDto;
        }
    }
}