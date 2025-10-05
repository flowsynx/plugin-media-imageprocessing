using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class ResizeOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (parameter.Width <= 0 || parameter.Height <= 0)
            throw new ArgumentException("Resize requires positive Width and Height.");

        image.Mutate(x => x.Resize(parameter.Width, parameter.Height));
    }
}