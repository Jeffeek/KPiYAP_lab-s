using System;
using System.Linq;

namespace Lab_no3
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteNumber();
            Function();
            GuestFloor();
            Console.ReadLine();
        }

        static void WriteNumber()
        {
            var check = new CheckNumber();
            check.Check();
        }

        static void Function()
        {
            Console.WriteLine("Введите три целочисленных числа через запятую(int k,int z,int b): ");
            var numbers = Console.ReadLine()
                                            .Split(',')
                                            .Select(int.Parse)
                                            .ToArray();
            double result = MathFunc.Function(numbers[0],numbers[1], numbers[2]);
            Console.WriteLine($"Результат: {result}");
        }

        static void GuestFloor()
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
