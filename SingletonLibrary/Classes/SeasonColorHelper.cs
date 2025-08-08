using System.Drawing;

namespace SingletonLibrary.Classes;

public class SeasonColorHelper
{
    private static readonly Dictionary<Season, Color> SeasonColors = new()
    {
        { Season.Winter, Color.LightBlue },
        { Season.Spring, Color.LightGreen },
        { Season.Summer, Color.Yellow },
        { Season.Autumn, Color.Orange }
    };

        public static Color GetSeasonColor()
        {
            var season = GetCurrentSeason();
            var test = SeasonColors.TryGetValue(season, out var color) ? color : Color.Gray;
            return test;
        }

    private static Season GetCurrentSeason() =>
        DateTime.Now.Month switch
        {
            12 or 1 or 2 => Season.Winter,
            3 or 4 or 5 => Season.Spring,
            6 or 7 or 8 => Season.Summer,
            9 or 10 or 11 => Season.Autumn,
            _ => throw new ArgumentOutOfRangeException()
        };
}
