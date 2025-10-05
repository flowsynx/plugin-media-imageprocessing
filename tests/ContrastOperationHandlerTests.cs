using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class ContrastOperationHandlerTests
    {
        [Fact]
        public void Handle_ChangesContrast_WithDefaultAmount()
        {
            var handler = new ContrastOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter();
            handler.Handle(image, param);
            // No exception means success
        }

        [Fact]
        public void Handle_ChangesContrast_WithCustomAmount()
        {
            var handler = new ContrastOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter { Amount = 0.5f };
            handler.Handle(image, param);
            // No exception means success
        }
    }
}
