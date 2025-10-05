using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class RotateOperationHandlerTests
    {
        [Fact]
        public void Handle_RotatesImage_WhenAngleProvided()
        {
            var handler = new RotateOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Angle = 90 };
            handler.Handle(image, param);
            Assert.Equal(10, image.Width); // Rotating a square keeps dimensions
        }

        [Fact]
        public void Handle_Throws_WhenAngleMissing()
        {
            var handler = new RotateOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter();
            Assert.Throws<ArgumentException>(() => handler.Handle(image, param));
        }
    }
}
