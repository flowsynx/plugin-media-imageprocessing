using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class SharpenOperationHandlerTests
    {
        [Fact]
        public void Handle_SharpensImage_WithDefaultSigma()
        {
            var handler = new SharpenOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter();
            handler.Handle(image, param);
            // No exception means success
        }

        [Fact]
        public void Handle_SharpensImage_WithCustomSigma()
        {
            var handler = new SharpenOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Radius = 1.5f };
            handler.Handle(image, param);
            // No exception means success
        }
    }
}
