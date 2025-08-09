using DatesAndTimesSampleApp.Classes;

namespace DatesAndTimesSampleApp;
internal partial class Program
{
    static void Main(string[] args)
    {
        if (DateTimeOffset.TryParse("2023-02-11 13:40:52.000 +0700", out var dt))
        {
            var date = dt.Date;
        }

        SpectreConsoleHelpers.ExitPrompt();
    }
}
