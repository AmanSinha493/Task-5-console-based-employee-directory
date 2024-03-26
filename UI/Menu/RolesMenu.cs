namespace employees;

class RolesMenu : IMenu
{
    IHandleCommands? menu = null;
    public RolesMenu(IHandleCommands menu)
    {
        this.menu = menu;
    }
    public void DisplayMenu()
    {
        // Console.Clear(); 
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------ Role Handling ------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("--add for  Add Role");
        Console.WriteLine("--display for Displaying Employees List");
        Console.WriteLine("--help for  Help");
        Console.WriteLine("--back to return to main menu ");
        menu!.HandleCommands();
    }
}