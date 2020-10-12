using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab_no5.Models
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class XmlToJsonConverter
    {
        public void Convert()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Person));
            var obj = new Person()
            {
                Name = "Misha",
                Age = 18
            };

            string jsonString = "";
            using (var stream = new MemoryStream())
            {
                xml.Serialize(stream, obj);
                jsonString = JsonConverter
            }
        }
    }
}
