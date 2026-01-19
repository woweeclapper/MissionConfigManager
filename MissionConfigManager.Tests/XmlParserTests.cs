
using MissionConfigManager.Core;

namespace MissionConfigManager.Tests
{
    public class XmlParserTests
    {
        [Fact]
        public void LoadsModulesFromXml()
        {
            var modules = XmlConfigLoader.Load("sample-config.xml");

            Assert.NotEmpty(modules);
            Assert.Equal("PowerSystem", modules[0].Name);
        }
    }
}
