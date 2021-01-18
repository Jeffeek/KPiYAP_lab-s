using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace Lab_no15._3
{
    internal class Program
    {
        private static readonly string _path = $"{Directory.GetCurrentDirectory()}\\humans.json";

        private static void Main(string[] args)
        {
            var humans = new[]
                         {
                             new Human()
                             {
                                 Address = new Address()
                                           {
                                               Number = 12,
                                               Room = 33,
                                               Street = "Staraya"
                                           },
                                 Age = 30,
                                 Name = "Beb"
                             },
                             new Human()
                             {
                                 Address = new Address()
                                           {
                                               Number = 33,
                                               Room = 12,
                                               Street = "Jimbo"
                                           },
                                 Age = 90,
                                 Name = "Atras"
                             },
                             new Human()
                             {
                                 Address = new Address()
                                           {
                                               Number = 13,
                                               Room = 1,
                                               Street = "Polskaya"
                                           },
                                 Age = 48,
                                 Name = "Golden"
                             }
                         };
            Serialize(humans);
        }

        private static void Serialize(IEnumerable<Human> humans)
        {
            File.WriteAllText(_path, "");
            var asArrayHumans = humans as Human[] ?? humans.ToArray();
            var serializer = new DataContractJsonSerializer(typeof(Human[]));
            using var stream = new FileStream(_path, FileMode.Open);
            serializer.WriteObject(stream, asArrayHumans);
        }
    }
}
