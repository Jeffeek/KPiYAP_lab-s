using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Lab_no4.Models;

namespace Lab_no4.View
{
    class MainView
    {
        private void StartMessage() => Console.WriteLine("Добро пожаловать!");

        public MainView()
        {
            StartMessage();
            StartView();
        }

        private void StartView()
        {
            Console.WriteLine("Давайте создадим десятиугольник");
            Console.WriteLine("Вы можете: \n1. ввести координаты (20 штук!) или \n2. заполнить их рандомно");
            Decagon decagon = new Decagon();
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                if (answer == 1)
                {
                    CreateDecagonByHand(decagon);
                }
                else if (answer == 2)
                {
                    CreateDecagonRandomly(decagon);
                }

                Console.WriteLine("Десятиугольник готов!");
            }

            Console.WriteLine($"Теперь мы можем найти периметр этого десятиугольника: {decagon.GetPerimeter()}");
            NumberView();
        }

        private void NumberView()
        {
            Console.WriteLine("Второе задание. Введите число, сумму цифр которых вы хотите посчитать: ");
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
                int sum = answer
                    .ToString()
                    .Select(x => int.Parse(x.ToString()))
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
            List<Point> points = new List<Point>();
            int x, y;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Введите {i + 1} точку: ");
                Console.WriteLine("X: ");
                x = int.Parse(Console.ReadLine());
                Console.WriteLine("Y: ");
                y = int.Parse(Console.ReadLine());
                Point point = new Point(x, y);
                points.Add(point);
            }
            decagon.FillCoordinates(points.ToArray());
        }
    }
}
