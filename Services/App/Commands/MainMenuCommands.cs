using CommandLine;
namespace employees;

class MainMenuCommands
{
    [Option("employee", HelpText = "Add an employee")]
    public bool Employee { get; set; }

    [Option("role", HelpText = "Display employee list")]
    public bool Role { get; set; }

    [Option("exit", HelpText = "Exit Program")]
    public bool Exit { get; set; }
}
