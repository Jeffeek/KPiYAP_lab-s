﻿#region Using namespaces

using System;

#endregion

namespace Labe_no11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            PlayWithArr();
            PlayWithComplexNumber();
            Console.ReadLine();
        }

        private static void PlayWithArr()
        {
            var arrWorker = new ArrayWorker();
            var arr = arrWorker.GetArray();
            arrWorker.PrintArray(arr);
            Console.WriteLine(new string('-', 40));
            arrWorker.Sort(arr);
            arrWorker.PrintArray(arr);
        }

        private static void PlayWithComplexNumber()
        {
            IBuilder<Complex> cbuilder = new ConsoleReadComplexBuilder();
            var complex1 = cbuilder.Build();
            var complex2 = cbuilder.Build();
            Console.WriteLine($"Первое число: {complex1}");
            Console.WriteLine($"Второе число: {complex2}");

            if (complex1.CompareTo(complex2) == 1)
                Console.WriteLine("Первое комплексное число больше!");

            if (complex1.CompareTo(complex2) == -1)
                Console.WriteLine("Второе комплексное число больше!");

            if (complex1.CompareTo(complex2) == 0)
                Console.WriteLine("Комплексные числа равны!");
        }
    }
}