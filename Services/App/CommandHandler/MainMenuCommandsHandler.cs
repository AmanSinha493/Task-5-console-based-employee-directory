using System;
using CommandLine;
namespace employees;


class MainMenuCommandsHandler : IHandleCommands
{
    public void HandleCommands()
    {
        bool loopContinue = true;
        bool isFirstTime = true;
        do
        {
            if (isFirstTime)
            {
                isFirstTime = false;
            }
            else
            {
                string? newArgs = Console.ReadLine();
                Parser.Default.ParseArguments<MainMenuCommands>(newArgs?.Split(' '))
                .WithParsed(options =>
                {
                    if (options.Employee)
                    {
                        // EmployeesCommandHandler employee = new();
                        IMenu menu = new EmployeesMenu (new EmployeesCommandHandler());
                        menu.DisplayMenu();
                    }
                    else if (options.Role)
                    {
                        // RolesCommandHandler role = new();
                        IMenu menu = new RolesMenu(new RolesCommandHandler());
                        menu.DisplayMenu();
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
