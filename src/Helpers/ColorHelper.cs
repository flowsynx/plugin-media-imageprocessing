using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using System.Globalization;

namespace FlowSynx.Plugins.Media.ImageProcessing.Helpers;

/// <summary>
/// 
/// Provides utility methods for parsing color representations into <see cref="Rgba32"/> format.
/// </summary>
/// <remarks>This class includes methods for converting color strings, such as named colors, hexadecimal values,
/// and "rgb"/"rgba" formats, into <see cref="Rgba32"/> instances. It is designed to handle common color formats used in
/// CSS and other contexts.</remarks>
public static class ColorHelper
{
    /// <example>
    /// <code>
    /// // Named color
    /// var color1 = ColorHelper.ParseToRgba32("red"); // R:255, G:0, B:0, A:255
    ///
    /// // Hexadecimal color
    /// var color2 = ColorHelper.ParseToRgba32("#00FF00"); // R:0, G:255, B:0, A:255
    ///
    /// // RGB format
    /// var color3 = ColorHelper.ParseToRgba32("rgb(0,0,255)"); // R:0, G:0, B:255, A:255
    ///
    /// // RGBA format
    /// var color4 = ColorHelper.ParseToRgba32("rgba(255,255,0,0.5)"); // R:255, G:255, B:0, A:128
    /// </code>
    /// </example>
    public static Rgba32 ParseToRgba32(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentNullException(nameof(input));

        string value = input.Trim();

        // Case-insensitive check for "rgba"
        if (value.StartsWith("rgba", StringComparison.OrdinalIgnoreCase))
        {
            return ParseRgba(value);
        }

        // Case-insensitive check for "rgb"
        if (value.StartsWith("rgb", StringComparison.OrdinalIgnoreCase))
        {
            return ParseRgb(value);
        }

        // Otherwise, treat as named or hex color (case-insensitive)
        return Color.Parse(value).ToPixel<Rgba32>();
    }

    private static Rgba32 ParseRgba(string rgbaString)
    {
        string cleaned = rgbaString
            .Trim()
            .Replace("rgba(", "", StringComparison.OrdinalIgnoreCase)
            .Replace(")", "", StringComparison.OrdinalIgnoreCase);

        var parts = cleaned.Split(',', StringSplitOptions.TrimEntries);
        if (parts.Length != 4)
            throw new FormatException($"Invalid RGBA format: {rgbaString}");

        byte r = byte.Parse(parts[0]);
        byte g = byte.Parse(parts[1]);
        byte b = byte.Parse(parts[2]);
        byte a = (byte)(float.Parse(parts[3], CultureInfo.InvariantCulture) * 255);

        return new Rgba32(r, g, b, a);
    }

    private static Rgba32 ParseRgb(string rgbString)
    {
        string cleaned = rgbString
            .Trim()
            .Replace("rgb(", "", StringComparison.OrdinalIgnoreCase)
            .Replace(")", "", StringComparison.OrdinalIgnoreCase);

        var parts = cleaned.Split(',', StringSplitOptions.TrimEntries);
        if (parts.Length != 3)
            throw new FormatException($"Invalid RGB format: {rgbString}");

        byte r = byte.Parse(parts[0]);
        byte g = byte.Parse(parts[1]);
        byte b = byte.Parse(parts[2]);

        return new Rgba32(r, g, b, 255);
    }
}