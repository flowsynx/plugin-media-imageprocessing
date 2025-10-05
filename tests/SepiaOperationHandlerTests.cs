using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class SepiaOperationHandlerTests
    {
        [Fact]
        public void Handle_ConvertsImageToSepia()
        {
            var handler = new SepiaOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter();
            handler.Handle(image, param);
            // No exception means success
        }
    }
}
