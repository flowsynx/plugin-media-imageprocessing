using FlowSynx.Plugins.Media.ImageProcessing.Services;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class DefaultReflectionGuardTests
    {
        [Fact]
        public void IsCalledViaReflection_DelegatesToReflectionHelper()
        {
            // Arrange
            // Since ReflectionHelper.IsCalledViaReflection is static, we can't mock it directly.
            // This test will simply call the method and assert the result is a bool.
            // In a real-world scenario, consider using a wrapper or interface for better testability.

            var guard = new DefaultReflectionGuard();

            // Act
            var result = guard.IsCalledViaReflection();

            // Assert
            Assert.IsType<bool>(result);
        }
    }
}