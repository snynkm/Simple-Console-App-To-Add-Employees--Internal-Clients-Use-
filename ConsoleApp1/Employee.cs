using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Project1
{
    class Employee
    {
        private static int employeeCount;
        private static int employeeID = 1000 + employeeCount;
        private int empID;
        private string firstName;
        private string lastName;
        private string fullName;
        private string email;
        public static string specialChar = "~!@#$%^&...";

        public int EmployeeID
        {
            get { return this.empID; }
            set { this.empID = value; }
        }
        public string FirstName
        {
            get { return this.firstName; }
            set { this.firstName = RemoveSpaces(value); }
        }
        public string LastName
        {
            get { return this.lastName; }
            set { this.lastName = RemoveSpaces(value); }
        }
        public string EmployeeEmail
        {
            get { return this.email; }
            set { this.email = value; }
        }
        public string FullName
        {
            get { return $"{this.firstName.ToUpper()} {this.lastName.ToUpper()}"; }
            set { this.fullName = value; }
        }

        public Employee(int employeeID)
        {
            empID = employeeID;
        }

        // get next available employee ID
        public static int AddEmployeeID()
        {
            employeeCount++;
            employeeID++;
            return employeeID;
        }

        // generate new employee email
        public static string AddEmployeeEmail(Employee employee)
        {

            employee.EmployeeEmail = $"{employee.FirstName.Substring(0, 1)}" +
                $"{employee.LastName}" +
                $"{employee.EmployeeID.ToString().Substring(0, 1)}" +
                $"{(employee.EmployeeID % 100).ToString()}" +
                $"{Employee.RandomNumber()}" +
                $"@gamecompany.com";
            return employee.EmployeeEmail;
        }

        // get random number
        public static int RandomNumber()
        {
            Random rnd = new Random();
            int randNum = rnd.Next(1, 10);
            return randNum;
        }

        // remove white spaces
        public static string RemoveSpaces(string name)
        {
            return Regex.Replace(name, @" ", "");
        }

        // display employee as string
        public override string ToString()
        {
            return $"Employee ID: {this.EmployeeID}\nName: {this.FullName}\nEmail: {this.EmployeeEmail}\n";
        }
    }
}
