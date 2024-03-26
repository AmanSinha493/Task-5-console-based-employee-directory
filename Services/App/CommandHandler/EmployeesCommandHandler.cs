using System;
using CommandLine;
namespace employees;


class EmployeesCommandHandler:IHandleCommands
{
    ICrudOperation<Employee>? employeeManager = null;
    public EmployeesCommandHandler()
    {
        this.employeeManager = new EmployeeManagement();
    }
    public void HandleCommands()
    {
        // DisplayMenu.EmployeeMenu();
        bool loopContinue = true;
        do
        {
            string? newArgs = Console.ReadLine();
            Parser.Default.ParseArguments<EmployeeCommands>(newArgs?.Split(' '))
            .WithParsed(options =>
            {
                if (options.AddEmployee)
                {
                    var emp = new Employee();
                    employeeManager?.GetDetails(emp, false);
                }
                else if (options.EmployeeNoToDelete != null)
                {
                    employeeManager?.Delete(options.EmployeeNoToDelete);
                }
                else if (options.EmployeeNoToEdit != null)
                {
                    Console.WriteLine("\nSaved Details\n");
                    employeeManager?.DisplayById(options.EmployeeNoToEdit);
                    Console.WriteLine("\nEnter new details\n");
                    employeeManager?.Edit(options.EmployeeNoToEdit);
                }
                else if (options.EmployeeNoToDisplay != null)
                {
                    Console.WriteLine("\n--------------------------------------------------------------------------- Employee Detail ---------------------------------------------------------------------------\n");
                    Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                    employeeManager?.DisplayById(options.EmployeeNoToDisplay);
                }
                else if (options.DisplayEmployeeList)
                {
                    Console.WriteLine("\n--------------------------------------------------------------------------- Employees Details -------------------------------------------------------------------------\n");
                    Console.WriteLine("\n-----------------------------------------------------------------------------------------------------------------------------------------------------------------------\n");
                    employeeManager?.DisplayList();
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

}
