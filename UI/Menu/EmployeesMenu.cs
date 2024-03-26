namespace employees;

class EmployeesMenu:IMenu
{
    IHandleCommands? menu = null;
    public EmployeesMenu(IHandleCommands menu)
    {
        this.menu = menu;
    }
     public void DisplayMenu()
    {
        // Console.Clear(); 
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------ Employee Handling ------------------------------------------------");
        Console.WriteLine();
        Console.WriteLine("--add for  Add Employee");
        Console.WriteLine("--displayAll for Displaying Employees List");
        Console.WriteLine("--display \"EmpNo\" for Displaying Particular Employee");
        Console.WriteLine("--edit  \"EmpNo\"   for Edit Employee ");
        Console.WriteLine("--delete \"EmpNo\"  for Delete Employee");
        Console.WriteLine("--help for  Help");
        Console.WriteLine("--back to return to main menu ");
        menu!.HandleCommands();
    }
}