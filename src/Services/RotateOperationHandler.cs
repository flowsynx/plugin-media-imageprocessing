using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class RotateOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (parameter.Angle == 0)
            throw new ArgumentException("Rotate requires an Angle.");

        image.Mutate(x => x.Rotate(parameter.Angle));
    }
}