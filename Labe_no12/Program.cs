using System;

namespace Labe_no12
{
    class Program
    {
        static void Main(string[] args)
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
                double startPoint = GetDouble();
                Console.WriteLine("Введите q: ");
                double q = GetDouble();
                try
                {
                    geometricProgression = new GeometricProgression(startPoint, q);
                    Console.WriteLine("Какой элемент прогрессии взять?");
                    int num = GetInt();
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

        static double GetDouble()
        {
            double result;
            string typedNum = "";
            Console.WriteLine("Введите число с плавающей запятой: ");
            typedNum = Console.ReadLine();
            while (!double.TryParse(typedNum, out result))
            {
                Console.WriteLine("Прикол\nВведите число с плавающей запятой: ");
                typedNum = Console.ReadLine();
            }
            return result;
        }

        static int GetInt()
        {
            int result;
            string typedNum = "";
            Console.WriteLine("Введите число: ");
            typedNum = Console.ReadLine();
            while (!int.TryParse(typedNum, out result))
            {
                Console.WriteLine("Прикол\nВведите число: ");
                typedNum = Console.ReadLine();
            }
            return result;
        }
    }
}
