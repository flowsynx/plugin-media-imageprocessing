using FlowSynx.PluginCore;
using FlowSynx.Plugins.Media.ImageProcessing.Models;
using FlowSynx.Plugins.Media.ImageProcessing.Services;
using Moq;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class ImageProcessingPluginTests
    {
        private readonly Mock<IReflectionGuard> _reflectionGuardMock;
        private readonly Mock<IGuidProvider> _guidProviderMock;
        private readonly Mock<IPluginLogger> _loggerMock;
        private readonly ImageProcessingPlugin _plugin;

        public ImageProcessingPluginTests()
        {
            _reflectionGuardMock = new Mock<IReflectionGuard>();
            _reflectionGuardMock.Setup(r => r.IsCalledViaReflection()).Returns(false);
            _guidProviderMock = new Mock<IGuidProvider>();
            _loggerMock = new Mock<IPluginLogger>();

            _plugin = new ImageProcessingPlugin(_guidProviderMock.Object, _reflectionGuardMock.Object);
        }

        [Fact]
        public void Metadata_IsNotNull_AndHasExpectedValues()
        {
            var metadata = _plugin.Metadata;
            Assert.NotNull(metadata);
            Assert.Equal("ImageProcessing", metadata.Name);
            Assert.Equal("FlowSynx", metadata.CompanyName);
        }

        [Fact]
        public void SupportedOperations_ContainsKnownOperations()
        {
            Assert.Contains("resize", _plugin.SupportedOperations);
            Assert.Contains("rotate", _plugin.SupportedOperations);
        }

        [Fact]
        public void SpecificationsType_IsExpected()
        {
            Assert.Equal(typeof(ImageProcessingPluginSpecifications), _plugin.SpecificationsType);
        }

        [Fact]
        public async Task Initialize_SetsIsInitialized()
        {
            await _plugin.Initialize(_loggerMock.Object);
            // No exception means success
        }

        [Fact]
        public async Task ExecuteAsync_ThrowsIfNotInitialized()
        {
            var parameters = new PluginParameters();
            await Assert.ThrowsAsync<InvalidOperationException>(() => _plugin.ExecuteAsync(parameters, CancellationToken.None));
        }

        [Fact]
        public async Task ExecuteAsync_ThrowsIfOperationNotSupported()
        {
            await _plugin.Initialize(_loggerMock.Object);
            var parameters = new PluginParameters { { "Operation", "notarealop" }, { "Data", "" } };
            await Assert.ThrowsAsync<NotSupportedException>(() => _plugin.ExecuteAsync(parameters, CancellationToken.None));
        }

        [Fact]
        public async Task ExecuteAsync_ThrowsIfCancelled()
        {
            await _plugin.Initialize(_loggerMock.Object);
            var cts = new CancellationTokenSource();
            cts.Cancel();
            await Assert.ThrowsAsync<OperationCanceledException>(() => _plugin.ExecuteAsync(new PluginParameters(), cts.Token));
        }
    }
}
