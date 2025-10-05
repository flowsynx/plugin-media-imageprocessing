using SixLabors.ImageSharp.PixelFormats;

namespace FlowSynx.Plugins.Media.ImageProcessing.Models;

internal class InputParameter
{
    public string Operation { get; set; } = string.Empty;
    public object? Data { get; set; }

    // Resize / Crop
    public int? Width { get; set; }
    public int? Height { get; set; }

    // Rotate
    public float? Angle { get; set; }

    // Blur / Sharpen
    public float? Radius { get; set; }

    // Brightness / Contrast
    public float? Amount { get; set; }

    // Flip
    public string? FlipMode { get; set; }

    // Watermark
    public string? WatermarkText { get; set; }

    public Rgba32? FromColor { get; set; }
    public Rgba32? ToColor { get; set; }
}