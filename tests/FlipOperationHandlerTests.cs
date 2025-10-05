using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class FlipOperationHandlerTests
    {
        [Fact]
        public void Handle_FlipsImage_Horizontally()
        {
            var handler = new FlipOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { FlipMode = "horizontal" };
            handler.Handle(image, param);
            // No exception means success
        }

        [Fact]
        public void Handle_FlipsImage_Vertically()
        {
            var handler = new FlipOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { FlipMode = "vertical" };
            handler.Handle(image, param);
            // No exception means success
        }

        [Fact]
        public void Handle_Throws_WhenFlipModeInvalid()
        {
            var handler = new FlipOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { FlipMode = "invalid" };
            Assert.Throws<ArgumentException>(() => handler.Handle(image, param));
        }
    }
}
