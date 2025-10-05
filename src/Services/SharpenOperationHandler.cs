using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class SharpenOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        float sigma = parameter.Radius ?? 3f;
        image.Mutate(x => x.GaussianSharpen(sigma));
    }
}