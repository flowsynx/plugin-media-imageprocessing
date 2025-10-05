using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class BlurOperationHandlerTests
    {
        [Fact]
        public void Handle_BlursImage_WithDefaultRadius()
        {
            var handler = new BlurOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(50, 50);
            var param = new InputParameter();
            handler.Handle(image, param);
            // No exception means success
        }

        [Fact]
        public void Handle_BlursImage_WithCustomRadius()
        {
            var handler = new BlurOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Radius = 2.5f };
            handler.Handle(image, param);
            // No exception means success
        }
    }
}
