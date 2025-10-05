using SixLabors.ImageSharp.PixelFormats;

namespace FlowSynx.Plugins.Media.ImageProcessing.Models;

internal class InputParameter
{
    public string Operation { get; set; } = string.Empty;
    public object? Data { get; set; }

    // Resize / Crop
    public int Width { get; set; }
    public int Height { get; set; }

    // Crop / Watermark
    public int Top { get; set; } = 10;
    public int Left { get; set; } = 10;

    // Rotate
    public float Angle { get; set; }

    // Blur / Sharpen
    public float Radius { get; set; }

    // Brightness / Contrast
    public float Amount { get; set; }

    // Flip
    public string FlipMode { get; set; } = string.Empty; // "horizontal", "vertical"

    // Watermark
    public string WatermarkText { get; set; } = string.Empty;
    public string WatermarkFontName { get; set; } = string.Empty;
    public int WatermarkFontSize { get; set; } = 24;
    public string WatermarkColor { get; set; } = "#FFFFFF";

    public string FromColor { get; set; } = string.Empty;
    public string ToColor { get; set; } = string.Empty;
}