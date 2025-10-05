using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class ResizeOperationHandlerTests
    {
        [Fact]
        public void Handle_ResizesImage_WhenWidthAndHeightProvided()
        {
            var handler = new ResizeOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Width = 5, Height = 5 };
            handler.Handle(image, param);
            Assert.Equal(5, image.Width);
            Assert.Equal(5, image.Height);
        }

        [Fact]
        public void Handle_Throws_WhenWidthOrHeightMissing()
        {
            var handler = new ResizeOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Width = 5 };
            Assert.Throws<ArgumentException>(() => handler.Handle(image, param));
        }
    }
}
