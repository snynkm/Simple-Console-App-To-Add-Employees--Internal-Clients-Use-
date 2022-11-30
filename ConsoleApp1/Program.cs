
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.Title = "Add Employee Program";
            List<Employee> employees = new List<Employee>();

            // add new employees as needed
            bool addMore = true;
            while (addMore != false)
            {
                string userInput = " ";
                AddEmployee(employees);
                while (!userInput.Equals("N"))
                {
                    Console.Write("Add another employee?(Y/N): ");
                    userInput = Console.ReadLine().ToUpper();
                    if (userInput.Length > 1 || userInput.Length < 1)
                    {
                        Console.WriteLine("Invalid option selected. Please try again. ");
                    }
                    else if (userInput.Equals("Y"))
                    {
                        break;
                    }
                    else if (userInput.Equals("N"))
                    {
                        addMore = false;
                        break;
                    }
                    else Console.WriteLine("Invalid option selected. Please try again. ");
                }

            }

            // display all employees
            Console.WriteLine("\nList of employees:\n");
            foreach (Employee e in employees)
            {
                Console.WriteLine(e);
            }

            Console.ReadLine();

        }

        // method to add employee
        public static void AddEmployee(List<Employee> employees)
        {

            int empID = Employee.AddEmployeeID();
            Employee employee = new Employee(empID);

            string firstNameInput;
            string lastNameInput;

            // check valid first name entry
            Console.Write("Enter new employee first name: ");
            firstNameInput = Console.ReadLine();

            while (firstNameInput.Length > 20
                || firstNameInput.Any(char.IsDigit)
                || firstNameInput.Any(char.IsSymbol)
                || string.IsNullOrWhiteSpace(firstNameInput))
            {
                if (string.IsNullOrWhiteSpace(firstNameInput))
                {
                    Console.Write("Name can't be blank. Please enter a first name: ");
                    firstNameInput = Console.ReadLine();
                }
                else if (firstNameInput.Length > 20)
                {
                    Console.Write($"Name can't exceed 20 characters. Please try again: ");
                    firstNameInput = Console.ReadLine();
                }
                else if (firstNameInput.Any(char.IsDigit) || firstNameInput.Any(char.IsSymbol))
                {
                    Console.Write($"Name can't include numbers or special characters. ({Employee.specialChar})\nPlease enter name again: ");
                    firstNameInput = Console.ReadLine();
                }
                else
                    break;
            }
            employee.FirstName = firstNameInput;

            // check valid last name entry
            Console.Write("Enter new employee last name: ");
            lastNameInput = Console.ReadLine();

            while (lastNameInput.Length > 20
                || lastNameInput.Any(char.IsDigit)
                || lastNameInput.Any(char.IsSymbol)
                || string.IsNullOrWhiteSpace(lastNameInput))
            {
                if (string.IsNullOrWhiteSpace(lastNameInput))
                {
                    Console.Write("Name can't be blank. Please enter a first name: ");
                    lastNameInput = Console.ReadLine();
                }
                else if (lastNameInput.Length > 20)
                {
                    Console.Write($"Name can't exceed 20 characters. Please try again: ");
                    lastNameInput = Console.ReadLine();
                }
                else if (lastNameInput.Any(char.IsDigit) || lastNameInput.Any(char.IsSymbol))
                {
                    Console.Write($"Name can't include numbers or special characters. ({Employee.specialChar})\nPlease enter name again: ");
                    lastNameInput = Console.ReadLine();
                }
                else
                    break;
            }
            employee.LastName = lastNameInput;

            Employee.AddEmployeeEmail(employee);
            employees.Add(employee);

        }

    }
}
