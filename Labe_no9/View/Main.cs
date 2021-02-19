#region Using derectives

using System;
using System.Diagnostics;
using System.Linq;
using Labe_no9.Enums;
using Labe_no9.Model;

#endregion

namespace Labe_no9.View
{
	public class Main
	{
		private readonly GovernmentWorker _worker;

		public Main()
		{
			_worker = new GovernmentWorker();
			Start();
		}

		public void Start()
		{
			while (true)
			{
				Console.WriteLine("1. Добавить государство в список");
				Console.WriteLine("2. Удалить государство");
				Console.WriteLine("3. Изменить государство");
				Console.WriteLine("4. Вывести все государства");
				Console.WriteLine("5. Вывести общую популяцию государств по типу");
				Console.WriteLine("6. Вывести общую площадь государств по типу");
				Console.WriteLine("7. Выход");

				switch (Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException()))
				{
					case 1:
					{
						var name = GetName();
						var capital = GetCapital();
						var population = GetPopulation();
						var area = GetArea();
						var type = GetType();
						_worker.AddGovernment(type, name, capital, population, area);

						break;
					}

					case 2:
					{
						var name = GetName();
						_worker.RemoveGovernment(name);

						break;
					}

					case 3:
					{
						var name = GetName();
						var item = _worker.GetCollection().SingleOrDefault(x => x.Name == name);
						ChangeGovernment(item);

						break;
					}

					case 4:
					{
						PrintAll();

						break;
					}

					case 5:
					{
						PrintPopulationByAllTypes();

						break;
					}

					case 6:
					{
						PrintAreasByAllTypes();

						break;
					}

					case 7:
					{
						Process.GetCurrentProcess().CloseMainWindow();

						break;
					}
				}
			}
		}

		private string GetName()
		{
			Console.WriteLine("Введите название страны: ");
			var name = Console.ReadLine();

			return name;
		}

		private string GetCapital()
		{
			Console.WriteLine("Введите столицу страны: ");
			var capital = Console.ReadLine();

			return capital;
		}

		private long GetPopulation()
		{
			Console.WriteLine("Введите популяцию страны: ");

			if (Int64.TryParse(Console.ReadLine(), out var population)) return population;

			throw new InvalidCastException(nameof(population));
		}

		private long GetArea()
		{
			Console.WriteLine("Введите площадь страны: ");

			if (Int64.TryParse(Console.ReadLine(), out var area)) return area;

			throw new InvalidCastException(nameof(area));
		}

		private new GovernmentType GetType()
		{
			Console.WriteLine("Введите тип правления страны: ");
			var types = Enum.GetValues(typeof(GovernmentType));
			foreach (var t in types) Console.WriteLine($"{t}");

			if (Enum.TryParse(Console.ReadLine(), out GovernmentType type)) return type;

			throw new InvalidCastException(nameof(type));
		}

		private void PrintAll()
		{
			foreach (var item in _worker.GetCollection()) Console.WriteLine(item);
		}

		private void ChangeGovernment(Government item)
		{
			Console.WriteLine("1. Изменить популяцию");
			Console.WriteLine("2. Изменить тип");
			Console.WriteLine("3. Изменить столицу");

			switch (Int32.Parse(Console.ReadLine() ?? throw new InvalidOperationException()))
			{
				case 1:
				{
					var population = GetPopulation();
					item.Population = population;

					break;
				}

				case 2:
				{
					var type = GetType();
					item.Type = type;

					break;
				}

				case 3:
				{
					var capital = GetCapital();
					item.Capital = capital;

					break;
				}
			}

			_worker.RemoveGovernment(item.Name);
			_worker.AddGovernment(item.Type, item.Name, item.Capital, item.Population, item.Area);
		}

		private void PrintPopulationByAllTypes()
		{
			var items = _worker.GetCollection().GroupBy(x => x.Type);
			foreach (var item in items) Console.WriteLine($"{item.Key} : {item.Sum(x => x.Population)} people");
		}

		private void PrintAreasByAllTypes()
		{
			var items = _worker.GetCollection().GroupBy(x => x.Type);
			foreach (var item in items) Console.WriteLine($"{item.Key} : {item.Sum(x => x.Area)} km^2");
		}
	}
}