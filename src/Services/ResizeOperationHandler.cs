using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class ResizeOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (!parameter.Width.HasValue || !parameter.Height.HasValue)
            throw new ArgumentException("Resize requires Width and Height.");
        image.Mutate(x => x.Resize(parameter.Width.Value, parameter.Height.Value));
    }
}