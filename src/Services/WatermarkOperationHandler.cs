using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.Fonts;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class WatermarkOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (string.IsNullOrWhiteSpace(parameter.WatermarkText))
            throw new ArgumentException("WatermarkText is required.");

        image.Mutate(x => x.DrawText(parameter.WatermarkText,
                                     SystemFonts.CreateFont("Arial", 24),
                                     Color.White,
                                     new PointF(10, 10)));
    }
}