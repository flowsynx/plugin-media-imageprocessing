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
    public int Top { get; set; } = 0;
    public int Left { get; set; } = 0;

    // Rotate
    public float Angle { get; set; }

    // Blur / Sharpen
    public float Radius { get; set; }

    // Brightness / Contrast
    public float Amount { get; set; }

    // Flip
    public string FlipMode { get; set; } = string.Empty; // "horizontal", "vertical"

    // Watermark
    public string Text { get; set; } = string.Empty;
    public string FontName { get; set; } = string.Empty;
    public int FontSize { get; set; } = 24;
    public string FontColor { get; set; } = "#FFFFFF";

    public string FromColor { get; set; } = string.Empty;
    public string ToColor { get; set; } = string.Empty;
}