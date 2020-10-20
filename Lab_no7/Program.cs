using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_no7
{
    class Program
    {
        static void Main(string[] args)
        {
            //QuadraticEqualation eq = QuadraticEqualation.ParseEqualation("12x^2-4x-5=0");
            //Console.WriteLine(eq);
            //Console.WriteLine("Введите квадратное уравнение: ");
            //QuadraticEqualation eq2 = QuadraticEqualation.ParseEqualation(Console.ReadLine());
            //Console.WriteLine(eq2);
            //Console.WriteLine("Введите строку для проверки количества цифр в ней: ");
            //string str = Console.ReadLine();
            //Console.WriteLine($"Количество цифр в строке: {CountOfDigits(str)}");
            var poem = new Poem();
            poem.StartTask();

            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Slow: ");
            sw.Start();
            poem.Slow("kek");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            sw.Reset();
            Console.WriteLine("Fast: ");
            sw.Start();
            poem.Fast("kek");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Console.ReadLine();
        }

        static int CountOfDigits(string str) => str.Count(Char.IsDigit);
    }
}
