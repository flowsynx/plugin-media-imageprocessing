using FlowSynx.Plugins.Media.ImageProcessing.Models;
using SixLabors.ImageSharp;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal interface IImageOperationHandler
{
    void Handle(Image image, InputParameter parameter);
}