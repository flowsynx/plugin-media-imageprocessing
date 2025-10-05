using FlowSynx.Plugins.Media.ImageProcessing.Services;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class GuidProviderTests
    {
        [Fact]
        public void NewGuid_ReturnsUniqueGuid()
        {
            var provider = new GuidProvider();
            var guid1 = provider.NewGuid();
            var guid2 = provider.NewGuid();
            Assert.NotEqual(Guid.Empty, guid1);
            Assert.NotEqual(Guid.Empty, guid2);
            Assert.NotEqual(guid1, guid2);
        }
    }
}
