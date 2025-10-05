using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class CropOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (!parameter.Width.HasValue || !parameter.Height.HasValue)
            throw new ArgumentException("Crop requires Width and Height.");
        image.Mutate(x => x.Crop(new Rectangle(0, 0, parameter.Width.Value, parameter.Height.Value)));
    }
}