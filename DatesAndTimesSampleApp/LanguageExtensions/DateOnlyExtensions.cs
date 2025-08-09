namespace DatesAndTimesSampleApp.LanguageExtensions;

public static class DateOnlyExtensions
{
    public static void Deconstruct(this DateOnly date, out int day, out int month, out int year)
        => (day, month, year) = (date.Day, date.Month, date.Year);
}