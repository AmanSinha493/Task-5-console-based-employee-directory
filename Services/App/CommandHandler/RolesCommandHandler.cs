using System;
using CommandLine;
namespace employees;


class RolesCommandHandler : IHandleCommands
{
    ICrudOperation<Role>? roleManager = null;
    public RolesCommandHandler()
    {
        this.roleManager = new RoleManagement();
    }

    public void HandleCommands()
    {
        // DisplayMenu.RoleMenu();
        bool loopContinue = true;
        do
        {
            string? newArgs = Console.ReadLine();
            Parser.Default.ParseArguments<RoleCommands>(newArgs?.Split(' '))
            .WithParsed(options =>
            {
                if (options.AddRole)
                {
                    var role = new Role();
                    roleManager?.GetDetails(role);
                }

                else if (options.DisplayRoleList)
                {
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("\n-------------------------- Roles Details ------------------------\n");
                    Console.WriteLine("\n-----------------------------------------------------------------\n");
                    roleManager?.DisplayList();
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
