using Spectre.Console;

namespace DatesAndTimesSampleApp.Classes;

internal class DateTimeOffsetSamples
{
    /// <summary>
    /// Demonstrates the conversion of string representations of dates and times
    /// into <see cref="DateTimeOffset"/> objects.
    /// </summary>
    /// <remarks>
    /// This method iterates through a collection of date strings and attempts to parse
    /// each one into a <see cref="DateTimeOffset"/>. If parsing is successful, the parsed
    /// value is displayed in the console. If parsing fails, an error message is displayed
    /// using Spectre.Console.
    /// </remarks>
    public static void StringCanConvertToDateTimeOffset()
    {

        SpectreConsoleHelpers.PrintCyan();

        string[] dates =
        [
            "2023-02-11 13:40:.000 +0700",
            "2023-02-11 13:40:52.000 +0100",
            "2023-02-45 13:40:52.000 -0700",
            "2023-02-11 13:40:52.000 -0100",
            "2023-02-11 13:40:52.000 +0000"
        ];

        /*
         * .ForEach() is used to iterate through each string in the array.
         */
        dates.ToList().ForEach(date =>
        {
            if (DateTimeOffset.TryParse(date, out var dateTimeOffset))
            {
                Console.WriteLine($"Parsed DateTimeOffset: {dateTimeOffset}");
            }
            else
            {
                AnsiConsole.MarkupLine($" [red bold]Failed to parse date: {date}[/]");
            }
        });


        Console.WriteLine();

        /*
         * foreach loop is used to iterate through each string in the array.
         */
        foreach (var date in dates)
        {
            if (DateTimeOffset.TryParse(date, out var dateTimeOffset))
            {
                Console.WriteLine($"Parsed DateTimeOffset: {dateTimeOffset}");
            }
            else
            {
                AnsiConsole.MarkupLine($" [red bold]Failed to parse date: {date}[/]");
            }
        }

    }
}
