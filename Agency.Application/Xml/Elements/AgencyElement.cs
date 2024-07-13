using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Agency.Application
{
    [XmlRoot("Agency")]
    public class AgencyElement
    {
        [XmlElement]
        public string Name { get; set; }

        [XmlElement] 
        public DateTime CreatedDate { get; set; }

        [XmlElement]
        public string Description { get; set; }
        
        [XmlArray("Agents")]
        public virtual List<AgentElement> Agents { get; set; }
    }
}
