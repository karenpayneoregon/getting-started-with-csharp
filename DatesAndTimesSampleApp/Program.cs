using DatesAndTimesSampleApp.Classes;
using Spectre.Console;

namespace DatesAndTimesSampleApp;
internal partial class Program
{
    static void Main(string[] args)
    {

        DateTimeOffsetSamples.StringCanConvertToDateTimeOffset();

        SpectreConsoleHelpers.ExitPrompt();
    }
}
