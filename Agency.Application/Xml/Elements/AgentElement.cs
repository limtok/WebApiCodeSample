using System.Xml.Serialization;

namespace Agency.Application
{
    [XmlType("Agent")]
    public class AgentElement
    {
        [XmlElement]
        public string Name { get; set; }
    }
}
