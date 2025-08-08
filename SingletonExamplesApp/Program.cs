using SingletonExamplesApp.Classes;
using SingletonLibrary.Classes;
using SingletonLibrary.Models;
using Spectre.Console;

namespace SingletonExamplesApp;
internal partial class Program
{
    static void Main(string[] args)
    {

        HelpDesk helpdesk = AppConfiguration.Instance.HelpDesk;
        AnsiConsole.MarkupLine($"[bold]Help Desk Information:[/]");
        AnsiConsole.MarkupLine($"[cyan]Phone:[/] {helpdesk.Phone}");
        AnsiConsole.MarkupLine($"[cyan]Email:[/] {helpdesk.Email}");


        SpectreConsoleHelpers.ExitPrompt();
    }
}
