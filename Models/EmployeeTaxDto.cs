using System.Runtime.InteropServices;

namespace Imaginnovate_Screening_Test.Models
{
    public class EmployeeTaxDto
    {
        public string EmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Doj { get; set; }

        public double SalaryYearly { get; set; }

        public double TaxAmount { get; set; }

        public double CessAmount { get; set; }
    }
}
