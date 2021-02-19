#region Using derectives

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Lab_no4.Models;

#endregion

namespace Lab_no4.View
{
	internal class MainView
	{
		public MainView()
		{
			StartMessage();
			StartView();
		}

		private void StartMessage() => Console.WriteLine("Добро пожаловать!");

		private void StartView()
		{
			Console.WriteLine("Давайте создадим десятиугольник");
			Console.WriteLine("Вы можете: \n1. ввести координаты (20 штук!) или \n2. заполнить их рандомно");
			var decagon = new Decagon();

			if (Int32.TryParse(Console.ReadLine(), out var answer))
			{
				if (answer == 1)
					CreateDecagonByHand(decagon);
				else if (answer == 2) CreateDecagonRandomly(decagon);

				Console.WriteLine("Десятиугольник готов!");
			}

			Console.WriteLine($"Теперь мы можем найти периметр этого десятиугольника: {decagon.GetPerimeter()}");
			NumberView();
		}

		private void NumberView()
		{
			Console.WriteLine("Второе задание. Введите число, сумму цифр которых вы хотите посчитать: ");

			if (Int32.TryParse(Console.ReadLine(), out var answer))
			{
				var sum = answer
						  .ToString()
						  .Select(x => Int32.Parse(x.ToString()))
						  .Sum();

				Console.WriteLine($"Сумма цифр вашего числа: {sum}");
			}
		}

		private void CreateDecagonRandomly(Decagon decagon)
		{
			decagon.FillCoordinatesRandomly();
		}

		private void CreateDecagonByHand(Decagon decagon)
		{
			var points = new List<Point>();
			int x, y;

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine($"Введите {i + 1} точку: ");
				Console.WriteLine("X: ");
				x = Int32.Parse(Console.ReadLine());
				Console.WriteLine("Y: ");
				y = Int32.Parse(Console.ReadLine());
				var point = new Point(x, y);
				points.Add(point);
			}

			decagon.FillCoordinates(points.ToArray());
		}
	}
}