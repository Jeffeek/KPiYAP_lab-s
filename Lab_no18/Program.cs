using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Xml;

namespace Lab_no18
{
    class Program
    {
        static void Main(string[] args)
        {
	        var document = new XmlDocument();
	        var xmlText = File.ReadAllText($"{Directory.GetCurrentDirectory()}\\governments.xml");
	        document.LoadXml(xmlText);
	        var countries = document.SelectSingleNode("countries") ?? throw new Exception();
	        var countriesList = new List<Government>();
	        for (var i = 0; i < countries.ChildNodes.Count; i++)
	        {
		        var country = countries.ChildNodes[i];
		        var name = country.SelectSingleNode("Name")?.InnerText;
				var capital = country.SelectSingleNode("Capital")?.InnerText;
				var population = int.Parse(country.SelectSingleNode("Population")?.InnerText!);
				var square = int.Parse(country.SelectSingleNode("Square")?.InnerText!);
				countriesList.Add(new Government()
				                  {
									  Capital = capital,
									  Name = name,
									  Population = population,
									  Square = square
				                  });
			}

	        RemoveLastGovernment(document);
	        SearchByPopulation(document, 1000, 5000);
        }

        private static XmlNode RemoveLastGovernment(XmlDocument document) => document.SelectSingleNode("countries")?.RemoveChild(document["countries"].LastChild) ?? throw new Exception();

        private static XmlDocument SearchByPopulation(XmlDocument document, int startRange, int finishRange)
        {
	        var countryChild = document.SelectSingleNode("countries");
	        var newDocument = new XmlDocument();
	        var node = newDocument.CreateElement("countries");
	        newDocument.AppendChild(node);
	        var countryChildNodes = countryChild?.ChildNodes;
	        if (countryChildNodes == null) return newDocument;
	        for (var i = 0; i < countryChildNodes.Count; i++)
	        {
		        var population = int.Parse(countryChildNodes?[i].SelectSingleNode("Population")?.InnerText!);
		        if (population >= startRange &&
		            population <= finishRange)
			        newDocument.FirstChild.AppendChild(countryChildNodes?[i]!);
	        }

	        return newDocument;
        }
    }
}
