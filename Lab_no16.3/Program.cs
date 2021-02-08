using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace Lab_no16._3
{
    class Program
    {
	    private static string _filePath = $"{Directory.GetCurrentDirectory()}\\dog.xml";

	    private static string _names =
			    "Арчи,Алекс,Амур," + 
				"Алтaй,Альф,Алмаз,Атос,Амиго,Аксель,Ангел,Адам,Арнольд,Август,Айрон" +
				"Акс,Альт,Арго,Арес,Атаман,Арс,Айран,Антей,Арамис,Азор,Апельсин" +
				"Азарт,Аркан,Аскольд,Артос,Антонио,Арман,Аватар,Арахис";

	    private static string _breeds =
		    "Бладхаунд,Блю-лейси,Бобтейл,Болгарский барак,Болоньез,Большой вандейский бассет-гриффон," +
		    "Большой вандейский гриффон,Большой мюнстерлендер,Большой швейцарский зенненхунд,Бордер-колли," +
		    "Бордер-терьер,Бордоский дог,Бородатый колли,Босерон,Бостон-терьер,Бразильский терьер," +
		    "Бразильский фила,Бретонский эпаньоль,Бриар,Брохольмер,Брюссельский гриффон,Буковинская овчарка," +
		    "Бульдог кампейро,Бульдог Катахулы,Бульмастиф,Бультерьер,Бурбонский бракк,Бурбуль," +
		    "Бурят-монгольский волкодав";

	    private static string[] housingTypes = {"Бездомная", "Для дома", "Для квартиры", "Для улицы"};

	    private static string _masterNames =
		    "Август,Августин,Авраам,Аврора,Агата,Агафон,Агнесса,Агния,Ада,Аделаида,Аделина,Адонис,Акайо,Акулина,Алан,Алевтина,Александр,Александра,Алексей,Алена,Алина,Алиса,Алла,Алсу,Альберт,Альбина,Альфия,Альфред,Амалия,Амелия,Анастасий,Анастасия,Анатолий,Ангелина,Андрей,Анжела,Анжелика,Анисий,Анна,Антон,Антонина,Анфиса,Аполлинарий,Аполлон,Ариадна,Арина,Аристарх,Аркадий,Арсен,Арсений,Артем,Артемий,Артур,Архип,Ася";

	    static void Main(string[] args)
	    {
		    Console.WriteLine("Рандомные собачьки: ");
		    var rnddogs = CreateRandomDogs(10);
		    ParseIntoList(rnddogs).ForEach(Console.WriteLine);
		    var rndDog = GetRandomDog();
		    Console.WriteLine("Рандомная собака: ");
		    var parsed = ParseDog(rndDog);
		    Console.WriteLine(parsed);
		    rnddogs = InsertAfter(rnddogs, 3, rndDog);
		    Console.WriteLine("После вставки на 4ю позицию: ");
		    ParseIntoList(rnddogs).ForEach(Console.WriteLine);
		    Console.WriteLine("Бездомные собаки: ");
		    var homeless = GetDogsByHousing(rnddogs, "Бездомная");
		    homeless.ForEach(Console.WriteLine);
		    var rndName = _names.Split(',')[new Random().Next(0, _names.Split(',').Length)];
			Console.WriteLine($"Собаки по имени: {rndName}");
			var byName = FindByName(rnddogs, rndName);
			Console.WriteLine(byName);
		}

	    private static XDocument CreateRandomDogs(int count)
	    {
		    var document = new XDocument();
		    var dogsNode = new XElement(XName.Get("dogs"));
		    for (var i = 0; i < count; i++)
		    {
			    var dog = GetRandomDog();
				dogsNode.Add(dog);
		    }
		    document.Add(dogsNode);
		    return document;
	    }

	    private static XElement GetRandomDog()
	    {
		    var rnd = new Random();
		    var dog = new XElement(XName.Get("dog"));
		    var names = _names.Split(',');
		    var breeds = _breeds.Split(',');
		    var masterNames = _masterNames.Split(',');
		    var name = names[rnd.Next(0, names.Length)];
		    var breed = breeds[rnd.Next(0, breeds.Length)];
		    var houseType = housingTypes[rnd.Next(0, housingTypes.Length)];
		    var age = rnd.Next(0, 16);
		    var master = masterNames[rnd.Next(0, masterNames.Length)];
		    var nameNode = new XElement(XName.Get("Name")) {Value = name};
		    var breedNode = new XElement(XName.Get("Breed"));
		    var ageNode = new XElement(XName.Get("Age")) {Value = age.ToString()};
		    breedNode.Value = breed;
		    var houseTypeNode = new XElement(XName.Get("HouseType")) {Value = houseType};
		    var masterNameNode = new XElement(XName.Get("MasterName")) {Value = master};
		    dog.Add(nameNode);
		    dog.Add(breedNode);
		    dog.Add(ageNode);
		    dog.Add(houseTypeNode);
		    dog.Add(masterNameNode);
		    return dog;
	    }

	    private static XDocument InsertAfter(XDocument document, int id, XElement dog)
	    {
		    var dogs = document.Element(XName.Get("dogs"));
		    var dogsNodes = dogs.Nodes();
		    if (dogsNodes.Count() < id)
		    {
			    Console.WriteLine("Невозможная операция");
			    return document;
		    }

		    var idDog = dogsNodes.ElementAt(id - 1);
		    idDog.AddAfterSelf(dog);
		    return document;
	    }

	    private static List<Dog> GetDogsByHousing(XDocument document, string housing)
	    {
		    var dogs = ParseIntoList(document);
		    return dogs.Where(dog => dog.HouseType == housing).ToList();
	    }

	    private static List<Dog> ParseIntoList(XDocument document)
	    {
		    var dogsNodes = document.XPathSelectElement("dogs").Nodes();
		    var list = new List<Dog>();
		    foreach (var node in dogsNodes)
		    {
			    var name = node.XPathSelectElement("Name").Value;
			    var breed = node.XPathSelectElement("Breed").Value;
			    var age = int.Parse(node.XPathSelectElement("Age").Value);
			    var houseType = node.XPathSelectElement("HouseType").Value;
			    var master = node.XPathSelectElement("MasterName").Value;
			    list.Add(new Dog()
			             {
							 Age = age,
							 Breed = breed,
							 HouseType = houseType,
							 MasterName = master,
							 Name = name
			             });
		    }

		    return list;
	    }

	    private static Dog FindByName(XDocument document, string name)
	    {
		    var dogs = ParseIntoList(document);
		    return dogs.FirstOrDefault(dog => dog.Name == name);
	    }

	    private static Dog ParseDog(XElement dogElement)
	    {
		    var name = dogElement.XPathSelectElement("Name").Value;
		    var breed = dogElement.XPathSelectElement("Breed").Value;
		    var age = int.Parse(dogElement.XPathSelectElement("Age").Value);
		    var houseType = dogElement.XPathSelectElement("HouseType").Value;
		    var master = dogElement.XPathSelectElement("MasterName").Value;
		    return new Dog()
		             {
			             Age = age,
			             Breed = breed,
			             HouseType = houseType,
			             MasterName = master,
			             Name = name
		             };
	    }
    }
}
