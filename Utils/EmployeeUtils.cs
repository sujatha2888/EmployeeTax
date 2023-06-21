using Imaginnovate_Screening_Test.Models;
using NodaTime;
using System;
using System.Runtime.InteropServices;

namespace Imaginnovate_Screening_Test.Utils
{
    public class EmployeeUtils
    {
        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        static List<Employee> Employees = new List<Employee>();

        public static List<Employee> EmployeeData()
        { 
            if (Employees.Count != 0) {  return Employees; }

            Employee emp = new Employee(EmployeeUtils.RandomString(), "First Name 1", "Last Name 1", "test@gmail.com", "9999999999", DateTime.Now.AddMonths(-2), 550000);
            Employees.Add(emp);

            emp = new Employee(EmployeeUtils.RandomString(), "First Name 2", "Last Name 2", "test1@gmail.com", "8888888888", DateTime.Now.AddMonths(-1), 250000);
            Employees.Add(emp);

            return Employees;
        }

        public static double getTotalSalary(DateTime doj, double SalaryPerMonth , int LOPDays) {
            double salaryPerDay = (SalaryPerMonth / 30);
            int totalWorkingDays = getTotalWorkingDaysInCurrentFY(doj);
            double lop = SalaryPerMonth / 30;
            return (totalWorkingDays * salaryPerDay - LOPDays * lop);
        }

        public static int getTotalWorkingDaysInCurrentFY(DateTime djo)
        {
            //string joiningDate = Convert.ToString(djo.ToString("yyyy-MM-dd"));
            DateTime startDate = Convert.ToDateTime(djo); // 4/21/2023
            int fyEndYear = DateTime.Now.Year; // 2023
            int emplJoinYear = djo.Year; // 2023
            int totalWorkingDays = 12 * 30; // 360
            if (emplJoinYear >= fyEndYear - 1 && djo.Month >= 4)
            {
                startDate = Convert.ToDateTime(djo); // 4/22/2023
                DateTime fyEndate = new DateTime(fyEndYear, 03, 31).AddDays(1); // 4/1/2023 
                double months = Math.Abs(12 * (startDate.Year - fyEndate.Year) + startDate.Month - fyEndate.Month);
                int remaingDays = DateTime.DaysInMonth(startDate.Year, startDate.Month); 
                totalWorkingDays = (int)(months * 30 + remaingDays);
            }

            return totalWorkingDays;
        }

        

        public static Double getTax(double salary)
        {

            Double tax = 0.0;

            if (salary <= 250000)
                tax = 0.0;
            else if (salary <= 500000)
                tax = 0.05 * (salary - 250000);
            else if (salary <= 1000000)
                tax = (0.1 * (salary - 500000)) + (0.05 * 250000);
            else
                tax = (0.2 * (salary - 1000000)) + (0.1 * 500000) + (0.05 * 250000);

            return round(tax, 2);
        }

        public static double round(double value, int places)
        {
            if (places < 0)
                throw new ArgumentException();

            long factor = (long)Math.Pow(10, places);
            value = value * factor;
            double tmp = Math.Round(value);
            return (double)tmp / factor;
        }

        public static Double getCess(double salary)
        {

            Double totalCess = 0.0;

            if (salary > 2500000)
            {

                salary = Math.Round(salary / 1000000.0) * 1000000;

                totalCess = (double)((2 * salary) / 100);
            }

            return totalCess;
        }

    }
}
