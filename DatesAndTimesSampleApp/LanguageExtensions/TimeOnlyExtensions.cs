namespace DatesAndTimesSampleApp.LanguageExtensions;

public static class TimeOnlyExtensions
{
    /// <summary>
    /// Format a <see cref="TimeOnly"/> with AM PM
    /// </summary>
    /// <param name="sender">TimeSpan to format</param>
    /// <param name="format">Optional format</param>
    public static string Formatted(this TimeOnly sender, string format = "hh:mm tt")
        => sender.ToString(format);

    /// <summary>
    /// Clean method for separating time parts
    /// </summary>
    public static void Deconstruct(this TimeOnly time, out int hour, out int minutes, out int seconds, out int milliseconds)
        => (hour, minutes, seconds, milliseconds) = (time.Hour, time.Minute, time.Second, time.Microsecond);

    public static void Deconstruct(this TimeOnly time, out int hour, out int minutes, out int seconds)
        => (hour, minutes, seconds) = (time.Hour, time.Minute, time.Second);


    /// <summary>
    /// Determine if TimeOnly is before another TimeOnly
    /// </summary>
    public static bool IsLessThan(this TimeOnly endTimeOnly, TimeOnly startTime)
        => endTimeOnly.CompareTo(startTime) < 0;
    

    public static bool IsLessThan<T>(this T sender, T compareTo) where T : IComparable<T>
        => compareTo.CompareTo(sender) < 0;

    /// <summary>
    /// Determine if TimeOnly is after another TimeOnly
    /// </summary>
    public static bool IsGreaterThan(this TimeOnly endTime, TimeOnly startTime)
        => endTime.CompareTo(startTime) > 0;


    public static bool IsGreaterThan<T>(this T sender, T compareTo) where T : IComparable
        => sender.CompareTo(compareTo) > 0;


    /// <summary>
    /// Determine if TimeOnly is the same as another TimeOnly
    /// </summary>
    public static bool AreSame(this TimeOnly endTimeOnly, TimeOnly startTimeOnly)
        => endTimeOnly.CompareTo(startTimeOnly) == 0;


    /// <summary>
    /// Get time between two TimeOnly as a TimeSpan
    /// </summary>
    /// <remarks>
    /// Sure this code can be circumvented but using an extension the name provides clarity
    /// </remarks>
    public static TimeSpan Duration(this TimeOnly endTimeOnly, TimeOnly starTimeOnly)
        => endTimeOnly - starTimeOnly;

    /// <summary>
    /// Get current time broken down by hour, minutes, seconds
    /// </summary>
    /// <param name="sender">DateTime</param>
    /// <returns>named value tuple</returns>
    public static (int hour, int minute, int second) TimeSegments(this TimeOnly sender)
        => (sender.Hour, sender.Minute, sender.Second);

}