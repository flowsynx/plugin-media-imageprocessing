namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class GuidProvider : IGuidProvider
{
    public Guid NewGuid() => Guid.NewGuid();
}