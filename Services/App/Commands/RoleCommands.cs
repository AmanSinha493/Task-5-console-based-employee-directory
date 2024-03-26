using CommandLine;
namespace employees;


class RoleCommands
{
    [Option("add", HelpText = "Add a Role")]
    public bool AddRole { get; set; }

    [Option("display", HelpText = "Display Role list")]
    public bool DisplayRoleList { get; set; }

    [Option("back", HelpText = "Exit Program")]
    public bool Back { get; set; }
}

