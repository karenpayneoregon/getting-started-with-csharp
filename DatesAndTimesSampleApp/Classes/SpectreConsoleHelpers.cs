using Spectre.Console;
using System.Runtime.CompilerServices;

namespace DatesAndTimesSampleApp.Classes;
public static class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();
        AnsiConsole.MarkupLine("[bold cyan]Press any key to exit...[/]");

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    /// <summary>
    /// Displays the file name and method name in cyan text.
    /// </summary>
    /// <param name="filePath">The full path of the source file.</param>
    /// <param name="methodName">The name of the calling method.</param>
    public static void PrintCyan([CallerFilePath] string? filePath = null, [CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{Path.GetFileNameWithoutExtension(filePath)}[/][yellow bold].[/][cyan]{methodName}[/]");
        Console.WriteLine();
    }

    /// <summary>
    /// Displays a horizontal line separator in the console with a grey style, centered on the screen.
    /// </summary>
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