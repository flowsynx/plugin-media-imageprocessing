using FlowSynx.Plugins.Media.ImageProcessing.Services;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class ColorReplaceOperationHandlerTests
    {
        [Fact]
        public void Handle_ReplacesColor_WhenFromAndToProvided()
        {
            var handler = new ColorReplaceOperationHandler();
            using var image = new Image<Rgba32>(1, 1);
            image[0, 0] = new Rgba32(1, 2, 3, 255);
            var param = new InputParameter { FromColor = "rgba(1, 2, 3, 255)", ToColor = "rgba(10, 20, 30, 255)" };
            handler.Handle(image, param);
            Assert.Equal(new Rgba32(1, 2, 3, 255), image[0, 0]);
        }

        [Fact]
        public void Handle_Throws_WhenFromOrToMissing()
        {
            var handler = new ColorReplaceOperationHandler();
            using var image = new Image<Rgba32>(1, 1);
            var param = new InputParameter { FromColor = "rgba(1, 2, 3, 255)" };
            Assert.Throws<ArgumentException>(() => handler.Handle(image, param));
        }
    }
}
