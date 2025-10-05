using FlowSynx.Plugins.Media.ImageProcessing.Helpers;
using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Processing;
using System.Reflection;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class WatermarkOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (string.IsNullOrWhiteSpace(parameter.WatermarkText))
            throw new ArgumentException("WatermarkText must not be empty.");

        if (parameter.WatermarkFontSize <= 0)
            throw new ArgumentException("Watermark font size must be greater than zero.");

        if (parameter.Top < 0)
            throw new ArgumentException("Watermark location top must be zero or a positive value.");

        if (parameter.Left < 0)
            throw new ArgumentException("Watermark location left must be zero or a positive value.");


        Font font;
        if (string.IsNullOrWhiteSpace(parameter.WatermarkFontName))
        {
            // Use embedded font as default
            font = LoadEmbeddedFont("FlowSynx.Plugins.Media.ImageProcessing.Fonts.DejaVuSerif.ttf", parameter.WatermarkFontSize);
        }
        else
        {
            font = SystemFonts.CreateFont(parameter.WatermarkFontName, parameter.WatermarkFontSize);
        }

        image.Mutate(x => x.DrawText(parameter.WatermarkText,
                                     font,
                                     ColorHelper.ParseToRgba32(parameter.WatermarkColor),
                                     new PointF(parameter.Left, parameter.Top)));
    }

    private static Font LoadEmbeddedFont(string resourceName, float fontSize)
    {
        var assembly = Assembly.GetExecutingAssembly();
        using Stream fontStream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new InvalidOperationException($"Font resource '{resourceName}' not found.");
        var fontCollection = new FontCollection();
        var fontFamily = fontCollection.Add(fontStream);
        return fontFamily.CreateFont(fontSize);
    }
}