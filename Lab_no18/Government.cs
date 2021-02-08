using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Lab_no18
{
    public sealed class Government
    {
	    [XmlAttribute("Name")]
        public string Name { get; set; }
	    [XmlAttribute("Capital")]
        public string Capital { get; set; }
	    [XmlAttribute("Population")]
        public int Population { get; set; }
	    [XmlAttribute("Square")]
        public int Square { get; set; }
    }
}
