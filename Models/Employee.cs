using Imaginnovate_Screening_Test.Utils;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Imaginnovate_Screening_Test.Models
{
    public class Employee
    {

        public Employee(string EmployeeID, string FirstName, string LastName, string Email, string PhoneNumber, DateTime DOJ, double Salary)
        {
            this.EmployeeID = EmployeeID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.DOJ = DOJ;
            this.Salary = Salary;

        }
        public string EmployeeID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^(0|91)?[6-9][0-9]{9}$", ErrorMessage = "Invalid Phone Number.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "DOJ")]
        [Required(ErrorMessage = "DOJ is required")]
        [DateLessThanOrEqualToToday]
        public DateTime DOJ { get; set; }

        [Display(Name = "Salary")]
        [Required(ErrorMessage = "Salary is required")]
        public double Salary { get; set; }

    }

}
