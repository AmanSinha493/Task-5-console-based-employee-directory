using System;
using System.ComponentModel.DataAnnotations;
using services.employee;

namespace employees
{
    internal class Employee
    {
        public static void AddEmployee(EmployeeModel employee, Boolean edit)
        {
            bool checkVal;
            if (!edit)
            {
                Console.Write("Enter the Employee No. : ");
                employee.Id = Convert.ToInt32(Console.ReadLine());
            }

            Fname:
            Console.Write("Enter the first name : ");
            employee.FName = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.FName, "name");
            if (!checkVal)
                goto Fname;

            Lname:
            Console.Write("Enter the last name  : ");
            employee.LName = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.LName, "name");
            if (!checkVal)
                goto Lname;

            Email:
            Console.Write("Enter the Email      : ");
            employee.Email = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.Email, "email");
            if (!checkVal)
                goto Email;

            Location:
            Console.Write("Enter the Location : ");
            employee.Location = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.Location, "Location");
            if (!checkVal)
                goto Location;

            Department:
            Console.Write("Enter the Department : ");
            employee.Department = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.Department, "department");
            if (!checkVal)
                goto Department;
            Role:
            Console.Write("Enter the Role : ");
            employee.Role = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.Role, "role");
            if (!checkVal)
                goto Role;
            Mobile:
            Console.Write("Enter the Mobile No. : ");
            employee.MobileNo = Console.ReadLine();
            checkVal = CheckValidations.Validation(employee.MobileNo, "mobile");
            if (!checkVal)
                goto Mobile;

            Console.Write("Enter the Status : ");
            employee.Status = Console.ReadLine();
            if (!edit)
                Console.WriteLine("Employee Added Successfully");
            else
                Console.WriteLine("Employee Updated Successfully");
        }
        public static void DisplayEmployeeList()
        {
            foreach (EmployeeModel employee in EmployeeModel.employeeList)
                DisplayEmployee(employee);
            if (EmployeeModel.employeeList.Count < 0)
                Console.WriteLine("No Record Found");
        }
        public static void DisplayEmployeeById(int id)
        {
            bool Flag = false;
            foreach (EmployeeModel employee in EmployeeModel.employeeList)
            {
                if (employee.Id == id)
                {
                    DisplayEmployee(employee);
                    Flag = true;
                    break;
                }
            }
            if (!Flag)
                Console.WriteLine("Employee Not Found");
        }
        public static void DisplayEmployee(EmployeeModel employee)
        {
            Console.WriteLine($"ID: {employee.Id,-10} | Name: {employee.FName + " " + employee.LName,-10} | Email: {employee.Email,-10} | Location: {employee.Location,-10} | Department:{employee.Department,-10} | Role:{employee.Role,-10} | Status:{employee.Status,-10}");
        }
        public static void DeleteEmployee(int id)
        {
            bool dltFlag = false;
            foreach (EmployeeModel employee in EmployeeModel.employeeList)
            {
                if (employee.Id == id)
                {
                    EmployeeModel.employeeList.Remove(employee);
                    Console.WriteLine("Employee Deleted Successfully");
                    dltFlag = true;
                    break;
                }
            }
            if (!dltFlag)
                Console.WriteLine("Employee Not Found");
        }
        public static void EditEmployee(int id)
        {
            bool editFlag = false;
            foreach (EmployeeModel employee in EmployeeModel.employeeList)
            {
                if (employee.Id == id)
                {
                    AddEmployee(employee, true);
                    editFlag = true;
                    break;
                }
            }
            if (!editFlag)
                Console.WriteLine("Employee Not Found");
        }
    }
}
