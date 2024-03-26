namespace employees;

class MainMenu : IMenu
{
    IHandleCommands? menu = null;
    public MainMenu(IHandleCommands menu)
    {
        this.menu = menu;
    }
    // menu.HandleCommands();
    public void DisplayMenu()
    {
        // Console.Clear();
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------ Main Menu ------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("--employee for  Employees Management");
        Console.WriteLine("--role for  Role Management");
        Console.WriteLine("--help for  Help");
        Console.WriteLine("--exit to Exit program");
        menu!.HandleCommands();
    }
}