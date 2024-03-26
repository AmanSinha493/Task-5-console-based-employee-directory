using System;
using employees;
namespace services.employee;

class Program
{
    static void Main(string[] args)
    {
        // MainMenuCommandsHandler menuHandler = new();
        IMenu menu=new MainMenu(new MainMenuCommandsHandler());
        menu.DisplayMenu();
        // menu.HandleCommands();
    }
}




