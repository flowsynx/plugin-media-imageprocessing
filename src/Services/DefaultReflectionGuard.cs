using FlowSynx.PluginCore.Helpers;

namespace FlowSynx.Plugins.Media.ImageProcessing.Services;

internal class DefaultReflectionGuard : IReflectionGuard
{
    public bool IsCalledViaReflection() => ReflectionHelper.IsCalledViaReflection();
}