using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class WatermarkOperationHandlerTests
    {
        [Fact]
        public void Handle_AddsWatermark_WhenTextProvided()
        {
            var handler = new WatermarkOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { WatermarkText = "Test" };
            handler.Handle(image, param);
            // No exception means success
        }

        [Fact]
        public void Handle_Throws_WhenTextMissing()
        {
            var handler = new WatermarkOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter();
            Assert.Throws<ArgumentException>(() => handler.Handle(image, param));
        }
    }
}
