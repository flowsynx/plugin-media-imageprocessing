using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class CropOperationHandlerTests
    {
        [Fact]
        public void Handle_CropsImage_WhenWidthAndHeightProvided()
        {
            var handler = new CropOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Width = 5, Height = 5, Left = 1, Top = 1 };
            handler.Handle(image, param);
            Assert.Equal(5, image.Width);
            Assert.Equal(5, image.Height);
        }

        [Fact]
        public void Handle_Throws_WhenWidthOrHeightMissing()
        {
            var handler = new CropOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Width = 5 };
            Assert.Throws<ArgumentException>(() => handler.Handle(image, param));
        }
    }
}
