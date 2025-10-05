using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class FlipOperationHandler : IImageOperationHandler
{
    public void Handle(Image image, InputParameter parameter)
    {
        if (string.IsNullOrEmpty(parameter.FlipMode))
            throw new ArgumentException("FlipMode is required.");

        var flipMode = parameter.FlipMode.ToLowerInvariant() switch
        {
            "horizontal" => FlipMode.Horizontal,
            "vertical" => FlipMode.Vertical,
            _ => throw new ArgumentException("FlipMode is not valid.")
        };

        image.Mutate(x => x.Flip(flipMode));
    }
}