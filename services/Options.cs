using CommandLine;
namespace employees
{
    class MenuOptions
    {
        [Option("employee", HelpText = "Add an employee")]
        public bool Employee { get; set; }

        [Option("role", HelpText = "Display employee list")]
        public bool Role { get; set; }

       [Option("exit", HelpText = "Exit Program")]
        public bool Exit { get; set; }
    }
    class EmployeeOptions
    {
        [Option("add", HelpText = "Add an employee")]
        public bool AddEmployee { get; set; }

        [Option("delete", HelpText = "Delete an employee")]
        public int EmployeeNoToDelete { get; set; }

        [Option("edit", HelpText = "Edit an employee")]
        public int EmployeeNoToEdit { get; set; }

        [Option("display", HelpText = "Display employee list")]
        public bool DisplayEmployeeList { get; set; }

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

 class RoleOptions
    {
        [Option("add", HelpText = "Add a Role")]
        public bool AddRole { get; set; }
        
        // [Option("delete", HelpText = "Delete an employee")]
        // public int RoleNoToDelete { get; set; }

        [Option("display", HelpText = "Display Role list")]
        public bool DisplayRoleList { get; set; }

        [Option("back", HelpText = "Exit Program")]
        public bool Back { get; set; }
    }

}