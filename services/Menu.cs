using System;
using CommandLine;
using services.employee;
namespace employees
{
    internal class DisplayMenu
    {
        public static void MainMenu()
        {
            Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------ Main Menu ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("--employee for  Employees Handling");
            Console.WriteLine("--role for  Role Handling");
            Console.WriteLine("--help for  Help");
            Console.WriteLine("--exit to Exit program");
        }
        public static void EmployeeMenu()
        {
            // Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------ Employee Handling ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("--add for  Add Employee");
            Console.WriteLine("--delete \"EmpNo\"  for Delete Employee");
            Console.WriteLine("--edit  \"EmpNo\"   for Edit Employee ");
            Console.WriteLine("--display for Displaying Employees List");
            Console.WriteLine("--help for  Help");
            Console.WriteLine("--back to return to main menu ");
        }
        public static void RoleMenu()
        {
            // Console.Clear(); 
            Console.WriteLine();
            Console.WriteLine("------------------------------------------------ Role Handling ------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine("--add for  Add Role");
            Console.WriteLine("--display for Displaying Employees List");
            Console.WriteLine("--help for  Help");
            Console.WriteLine("--back to return to main menu ");
        }
    }

    internal class HandelMenu
    {
        public static void EmployeeMenu()
        {
            DisplayMenu.EmployeeMenu();
            bool loopContinue = true;
            do
            {
                string? newArgs = Console.ReadLine();
                Parser.Default.ParseArguments<EmployeeOptions>(newArgs?.Split(' '))
                .WithParsed(options =>
                {
                    if (options.AddEmployee)
                    {
                        var emp = new EmployeeModel();
                        Employee.AddEmployee(emp, false);
                        EmployeeModel.employeeList.Add(emp);
                    }
                    else if (options.EmployeeNoToDelete > 0)
                    {
                        Employee.DeleteEmployee(options.EmployeeNoToDelete);
                    }
                    else if (options.EmployeeNoToEdit > 0)
                    {
                        Console.WriteLine("\nSaved Details\n");
                        Employee.DisplayEmployeeById(options.EmployeeNoToEdit);
                        Console.WriteLine("\nEnter new details\n");
                        Employee.EditEmployee(options.EmployeeNoToEdit);
                    }
                    else if (options.DisplayEmployeeList)
                    {
                        Console.WriteLine("\n------------------------------------------------ Employees Details ------------------------------------------------\n");
                        Employee.DisplayEmployeeList();
                    }
                    else if (options.Back)
                    {
                        loopContinue = false;
                    }
                    else
                    {
                        Console.WriteLine("No valid command-line options provided.");
                    }
                })
                .WithNotParsed(errors =>
                {
                    Console.WriteLine("Invalid command-line arguments. Use --add, --delete, --edit, or --display.");
                });
            } while (loopContinue);
        }

        public static void MainMenu()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            bool loopContinue = true;
            bool isFirstTime = true;
            do
            {
                DisplayMenu.MainMenu();
                if (isFirstTime)
                {
                    isFirstTime = false;
                }
                else
                {
                    string? newArgs = Console.ReadLine();
                    Parser.Default.ParseArguments<MenuOptions>(newArgs?.Split(' '))
                    .WithParsed(options =>
                    {
                        if (options.Employee)
                        {
                            HandelMenu.EmployeeMenu();
                        }
                        else if (options.Role)
                        {
                            // Employee.DeleteEmployee(options.EmployeeNoToDelete);
                        }
                        else if (options.Exit)
                        {
                            loopContinue = false;
                        }
                        else
                        {
                            Console.WriteLine("No valid command-line options provided.");
                        }
                    })
                    .WithNotParsed(errors =>
                    {
                        Console.WriteLine("Invalid command-line arguments. Use --add, --delete, --edit, or --display.");
                    });
                }
            } while (loopContinue);
        }

    }
}