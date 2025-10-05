using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class BlurOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        float radius = parameter.Radius ?? 5f;
        image.Mutate(x => x.GaussianBlur(radius));
    }
}