namespace DatesAndTimesSampleApp.LanguageExtensions;
internal static class DateTimeOffsetExtensions
{
    public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year, out int hour, out int minutes, out int seconds, out int milliseconds, out TimeSpan offset)
        => (day, month, year, hour, minutes, seconds, milliseconds, offset) =
            (date.Day, date.Month, date.Year, date.Hour, date.Minute, date.Second, date.Millisecond, date.Offset);

    public static void Deconstruct(this DateTimeOffset date, out int day, out int month, out int year)
        => (day, month, year) = (date.Day, date.Month, date.Year);
}