using System.Xml.Linq;

namespace MissionConfigManager.Core
{
    public static class XmlConfigLoaderExtensions
    {
        public static List<MissionModule> LoadFromString(string xml)
        {
            var doc = XDocument.Parse(xml);

            return doc.Root!
                .Elements("Module")
                .Select(m => new MissionModule
                {
                    Name = m.Attribute("name")!.Value,
                    Parameters = m.Elements("Parameter")
                        .Select(p => new MissionParameter
                        {
                            Key = p.Attribute("key")!.Value,
                            Value = p.Attribute("value")!.Value
                        }).ToList()
                }).ToList();
        }
    }
}
