using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class ImageProcessingPluginSpecificationsTests
    {
        [Fact]
        public void CanInstantiate_ImageProcessingPluginSpecifications()
        {
            // Act
            var specs = new ImageProcessingPluginSpecifications();

            // Assert
            Assert.NotNull(specs);
        }
    }
}