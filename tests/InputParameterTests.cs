using FlowSynx.Plugins.Media.ImageProcessing.Models;

namespace FlowSynx.Plugins.Media.ImageProcessing.UnitTests
{
    public class InputParameterTests
    {
        [Fact]
        public void Default_Properties_AreSet()
        {
            var param = new InputParameter();
            Assert.Equal(string.Empty, param.Operation);
            Assert.Null(param.Data);
        }
    }
}
