#region Using namespaces

using System;
using System.Linq;

#endregion

namespace Lab_no3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            WriteNumber();
            Function();
            GuestFloor();
            Console.ReadLine();
        }

        private static void WriteNumber()
        {
            var check = new CheckNumber();
            check.Check();
        }

        private static void Function()
        {
            Console.WriteLine("Введите три целочисленных числа через запятую(int k,int z,int b): ");

            var numbers = Console.ReadLine()
                                 .Split(',')
                                 .Select(Int32.Parse)
                                 .ToArray();

            var result = MathFunc.Function(numbers[0], numbers[1], numbers[2]);
            Console.WriteLine($"Результат: {result}");
        }

        private static void GuestFloor()
        {
            Console.WriteLine("Введите номер квартиры: ");
            var items = new CheckNumber().CheckInt();

            if (items.Item1)
            {
                var floor = MathFunc.GetPessangerFloor(items.Item2);
                Console.WriteLine($"Этаж: {floor}");
            }
        }
    }
}