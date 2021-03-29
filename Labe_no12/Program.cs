#region Using namespaces

using System;

#endregion

namespace Labe_no12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IProgression geometricProgression;

            try
            {
                geometricProgression = new GeometricProgression(2.11, 0);
            }
            catch (BadQException e)
            {
                Console.WriteLine(e.StackTrace);
            }

            geometricProgression = new GeometricProgression(2.11, 1.22);
            Console.WriteLine(geometricProgression.Sum(5));

            while (true)
            {
                Console.WriteLine("Введите начальную точку: ");
                var startPoint = GetDouble();
                Console.WriteLine("Введите q: ");
                var q = GetDouble();

                try
                {
                    geometricProgression = new GeometricProgression(startPoint, q);
                    Console.WriteLine("Какой элемент прогрессии взять?");
                    var num = GetInt();
                    Console.WriteLine($"{num} элемент: {geometricProgression.Get(num)}");
                    Console.WriteLine("Сумму прогрессии до какого элемента взять?");
                    num = GetInt();
                    Console.WriteLine($"Сумма до {num} элемента: {geometricProgression.Sum(num)}");
                }
                catch (BadQException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"Имя ошибки: {e.GetType()}");
                }
            }
        }

        private static double GetDouble()
        {
            double result;
            var typedNum = "";
            Console.WriteLine("Введите число с плавающей запятой: ");
            typedNum = Console.ReadLine();

            while (!Double.TryParse(typedNum, out result))
            {
                Console.WriteLine("Прикол\nВведите число с плавающей запятой: ");
                typedNum = Console.ReadLine();
            }

            return result;
        }

        private static int GetInt()
        {
            int result;
            var typedNum = "";
            Console.WriteLine("Введите число: ");
            typedNum = Console.ReadLine();

            while (!Int32.TryParse(typedNum, out result))
            {
                Console.WriteLine("Прикол\nВведите число: ");
                typedNum = Console.ReadLine();
            }

            return result;
        }
    }
}