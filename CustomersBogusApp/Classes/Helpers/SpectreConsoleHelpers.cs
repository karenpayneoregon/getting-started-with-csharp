using Serilog;
using Spectre.Console;
using System.Runtime.CompilerServices;

namespace CustomersBogusApp.Classes.Helpers;
public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold cyan]Press any key to exit...[/]");

        Console.ReadLine();
    }

    public static void PrintMethodName([CallerFilePath] string fileName = "", [CallerMemberName] string? methodName = null)
    {

        var caller = Path.GetFileNameWithoutExtension(fileName);

        AnsiConsole.MarkupLine($"[cyan]{caller}.{methodName}[/]");
        Log.Information($"Starting {methodName}");

        Console.WriteLine();
    }


    public static void LineSeparator()
    {
        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("grey")).Centered());
    }

    /// <summary>
    /// Spectre.Console  Add [ to [ and ] to ] so Children[0].Name changes to Children[[0]].Name
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleEscape(this string sender)
        => Markup.Escape(sender);

    /// <summary>
    /// Spectre.Console Removes markup from the specified string.
    /// </summary>
    /// <param name="sender"></param>
    /// <returns></returns>
    public static string ConsoleRemove(this string sender)
        => Markup.Remove(sender);
}