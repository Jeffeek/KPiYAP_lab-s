#region Using derectives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

#endregion

namespace Lab_no18._2
{
	public sealed class ShopMenu
	{
		private readonly InputOutputProvider _provider;
		private readonly Dictionary<int, Action> _menuChoice;
		private XDocument _document;

		public ShopMenu(InputOutputProvider provider, XDocument document)
		{
			_provider = provider;

			_menuChoice = new Dictionary<int, Action>
						  {
								  { 1, AddPC },
								  { 2, RemovePC },
								  { 3, SearchByCharacteristics },
								  { 4, SearchByName }
						  };

			_document = document;
			PrintProducts(_document);
		}

		public void Start() => PrintMenu();

		private void AddPC()
		{
			var products = _document.Element(XName.Get("shop")).Element(XName.Get("products")).Elements().ToList();
			_provider.Out("Введите имя для товара: ");
			var name = _provider.In();
			var deXElement = products.SingleOrDefault(pc => pc.XPathSelectElement("Name").Value == name);

			if (deXElement != null)
			{
				_provider.Out("Нашли компьютер с таким названием. Добавим ему количество на складе + 1");

				deXElement.XPathSelectElement("InStock").Value =
						(Int32.Parse(deXElement.XPathSelectElement("InStock").Value) + 1).ToString();

				PrintProducts(_document);
				PrintMenu();

				return;
			}

			_provider.Out("Введите название процессора: ");
			var cpu = _provider.In();
			_provider.Out("Введите название Видеокарты: ");
			var gpu = _provider.In();

			var newPc =
					$"<pc><Name>{name}</Name><characteristics><characteristic>{cpu}</characteristic><characteristic>{gpu}</characteristic></characteristics><InStock>1</InStock></pc>";

			var pcElement = XElement.Parse(newPc);
			products.Add(pcElement);
			_document = ParseFromList(products);
			PrintProducts(_document);
			PrintMenu();
		}

		private XDocument ParseFromList(List<XElement> list)
		{
			var doc = new XDocument(new XDeclaration("1.0", "utf-8", "no"));
			var shop = new XElement(XName.Get("shop"));
			doc.Add(shop);
			var products = new XElement(XName.Get("products"));
			shop.Add(products);
			foreach (var pc in list.Select(t => new XElement(t))) products.Add(pc);

			return doc;
		}

		private List<XElement> ParseToList(XDocument document) => document.Element(XName.Get("shop")).Element("products").Elements().ToList();

		private void RemovePC()
		{
			_provider.Out("Введите название компьютера, количество которого вы хотите уменьшить на 1");
			var name = _provider.In();
			var products = ParseToList(_document);
			var pc = products.SingleOrDefault(x => x.Element(XName.Get("Name")).Value == name);

			if (pc == null)
			{
				_provider.Out("Такого компьютера нет!");
				PrintMenu();

				return;
			}

			pc.Element(XName.Get("InStock")).Value = (Int32.Parse(pc.Element(XName.Get("InStock")).Value) - 1).ToString();
			if (Int32.Parse(pc.Element(XName.Get("InStock")).Value) == 0) products.Remove(pc);

			_document = ParseFromList(products);
			PrintProducts(_document);
			PrintMenu();
		}

		private void SearchByCharacteristics()
		{
			_provider.Out("Введите название процессора: ");
			var cpu = _provider.In();
			_provider.Out("Введите название видеокарты: ");
			var gpu = _provider.In();
			var products = ParseToList(_document);

			var pc = products.SingleOrDefault(x => x.Element(XName.Get("characteristics"))
													?
													.Element(XName.Get("cpu"))
													?
													.Value
												   == cpu
												   && x.Element(XName.Get("characteristics"))
													   ?
													   .Element(XName.Get("gpu"))
													   ?
													   .Value
												   == gpu);

			if (pc == null)
			{
				_provider.Out("Нет такого товара!");
				PrintMenu();

				return;
			}

			_provider.Out("Нашли такой товар: ");
			PrintProduct(pc);
			PrintMenu();
		}

		private void PrintProduct(XElement product)
		{
			_provider.Out(product.Element(XName.Get("Name")).Value);
			_provider.Out("Характеристики: ");
			var characteristics = product.Element(XName.Get("characteristics")).Elements();
			foreach (var characteristic in characteristics) _provider.Out(characteristic.Value);
			_provider.Out(product.Element(XName.Get("InStock")).Value);
		}

		private void SearchByName()
		{
			_provider.Out("Введите название: ");
			var name = _provider.In();
			var products = ParseToList(_document);
			var pc = products.SingleOrDefault(x => x.Element(XName.Get("Name")).Value == name);

			if (pc == null)
			{
				_provider.Out("Нет такого товара");
				PrintMenu();

				return;
			}

			_provider.Out("Нашли такой товар: ");
			PrintProduct(pc);
			PrintMenu();
		}

		private void PrintMenu()
		{
			_provider.Out("1. Добавить");
			_provider.Out("2. Удалить");
			_provider.Out("3. Вывести по характеристикам");
			_provider.Out("4. Вывести по названию");
			parse:
			var parseResult = Int32.TryParse(_provider.In(), out var result);

			if (!parseResult
				|| result < 1
				|| result > _menuChoice.Count)
				goto parse;

			_menuChoice[result]();
		}

		private void PrintProducts(XDocument document)
		{
			var products = document.Element(XName.Get("shop")).Element(XName.Get("products")).Elements();
			foreach (var pc in products) PrintProduct(pc);
		}
	}
}