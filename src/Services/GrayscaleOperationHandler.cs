using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class GrayscaleOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        image.Mutate(x => x.Grayscale());
    }
}