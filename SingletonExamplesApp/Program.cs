using SingletonExamplesApp.Classes;
using SingletonLibrary.Classes;
using SingletonLibrary.Models;
using Spectre.Console;
using System.Text.RegularExpressions;

namespace SingletonExamplesApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        var color = SeasonColorHelper.GetSeasonColorName();

        HelpDesk helpdesk = AppConfiguration.Instance.HelpDesk;
        AnsiConsole.MarkupLine($"[bold {color}]Help Desk Information:[/]");
        AnsiConsole.MarkupLine($"[{color}]Phone:[/] {helpdesk.Phone}");
        AnsiConsole.MarkupLine($"[{color}]Email:[/] {helpdesk.Email}");

   
        var input = "User Name (email@address.com)";
        var output = UserInfoRegex().Replace(input, string.Empty);
        AnsiConsole.MarkupLine($"[yellow]{output}[/]");



        SpectreConsoleHelpers.ExitPrompt();
    }

    [GeneratedRegex(@" ?\(.*?\)")]
    private static partial Regex UserInfoRegex();
}
