using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class BrightnessOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        float amount = parameter.Amount ?? 1f;
        image.Mutate(x => x.Brightness(amount));
    }
}