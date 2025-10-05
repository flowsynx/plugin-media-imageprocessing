using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class EdgeDetectionOperationHandlerTests
    {
        [Fact]
        public void Handle_DetectsEdges()
        {
            var handler = new EdgeDetectionOperationHandler();
            using var image = new Image<SixLabors.ImageSharp.PixelFormats.Rgba32>(10, 10);
            var param = new InputParameter();
            handler.Handle(image, param);
            // No exception means success
        }
    }
}
