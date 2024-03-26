using CommandLine;
namespace employees;

class EmployeeCommands
{
    [Option("add", HelpText = "Add an employee")]
    public bool AddEmployee { get; set; }

    [Option("delete", HelpText = "Delete an employee")]
    public string? EmployeeNoToDelete { get; set; }

    [Option("edit", HelpText = "Edit an employee")]
    public string? EmployeeNoToEdit { get; set; }

    [Option("displayAll", HelpText = "Display employee list")]
    public bool DisplayEmployeeList { get; set; }

    [Option("display", HelpText = "Display an employee")]
    public string? EmployeeNoToDisplay { get; set; }

    [Option("back", HelpText = "Exit Program")]
    public bool Back { get; set; }

    // [HelpOption]
    // public string GetUsage()
    // {
    //     return HelpText.AutoBuild(this);
    // }
    // public int[] x = [];
    // public IEnumerable<int> parameter
    // {
    //     get{return x;}
    //     set{x=value.ToArray();}
    // }
}



