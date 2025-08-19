using System.ComponentModel;
using System.Drawing;

namespace SingletonLibrary.Classes;

/// <summary>
/// Provides a singleton implementation for managing color-related operations.
/// </summary>
/// <remarks>
/// This class is designed to ensure a single instance is used throughout the application.
/// It includes functionality to retrieve and manage seasonal colors.
/// </remarks>
public sealed class ColorsHelper
{
    private static readonly Lazy<ColorsHelper> Lazy = new(() => new ColorsHelper());

    public static ColorsHelper Instance => Lazy.Value;

    /// <summary>
    /// Gets or sets the color associated with the current season.
    /// </summary>
    /// <remarks>
    /// The value of this property is determined based on the current month and is initialized
    /// using the <see cref="SeasonColorHelper.GetSeasonColor"/> method. It represents a seasonal color:
    /// Winter (LightBlue), Spring (LightGreen), Summer (Yellow), Autumn (Orange), or a fallback (Gray).
    /// </remarks>
    public Color SeasonColor { get; set; }

    private ColorsHelper()
    {
        SeasonColor = Color.FromName(SeasonColorHelper.GetSeasonColor().Name);
    }

    public static Color GetColorFromString(string colorString)
    {
        // Example for hexadecimal color string (e.g., "#FF0000" for red)
        if (colorString.StartsWith("#"))
        {
            return ColorTranslator.FromHtml(colorString);
        }
        // Example for named color string (e.g., "Red", "Blue")
        else
        {
            var converter = TypeDescriptor.GetConverter(typeof(Color)); // Use TypeDescriptor to get a TypeConverter instance
            return (Color)(converter.ConvertFromString(colorString) ?? Color.BlanchedAlmond); // Use the instance to call ConvertFromString
        }
    }
}
