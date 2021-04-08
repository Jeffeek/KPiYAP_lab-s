#region Using namespaces

using System;
using Lab_no5.Exceptions;
using Lab_no5.Models;

#endregion

namespace Lab_no5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var time = new TimeVelosiped();
            TypeSeconds_Exception(time);
            TypeMinutes_Exception(time);
            TypeHours_Exception(time);
            Console.WriteLine(time);

            AddHours_test(time);
            AddMinutes_test(time);
            AddSeconds_test(time);

            Console.WriteLine(time);
            Console.ReadLine();
        }

        private static void AddSeconds_test(TimeVelosiped time)
        {
            Console.WriteLine("Введите секунды (add)");

            if (Int32.TryParse(Console.ReadLine(), out var seconds))
                time.AddSeconds(seconds);
        }

        private static void AddMinutes_test(TimeVelosiped time)
        {
            Console.WriteLine("Введите минуты (add)");

            if (Int32.TryParse(Console.ReadLine(), out var min))
                time.AddMinutes(min);
        }

        private static void AddHours_test(TimeVelosiped time)
        {
            Console.WriteLine("Введите часы (add)");

            if (Int32.TryParse(Console.ReadLine(), out var hours))
                time.AddHours(hours);
        }

        private static void TypeSeconds_Exception(TimeVelosiped time)
        {
            Console.WriteLine("Введите секунды (set)");

            if (Int32.TryParse(Console.ReadLine(), out var seconds))
                try
                {
                    time.Seconds = seconds;
                }
                catch (TimeSecondException exception)
                {
                    Console.WriteLine(exception.Message);
                }
        }

        private static void TypeMinutes_Exception(TimeVelosiped time)
        {
            Console.WriteLine("Введите минуты (set)");

            if (Int32.TryParse(Console.ReadLine(), out var min))
                try
                {
                    time.Minutes = min;
                }
                catch (TimeMinuteException exception)
                {
                    Console.WriteLine(exception.Message);
                }
        }

        private static void TypeHours_Exception(TimeVelosiped time)
        {
            Console.WriteLine("Введите часы (set)");

            if (Int32.TryParse(Console.ReadLine(), out var hours))
                try
                {
                    time.Hours = hours;
                }
                catch (TimeHourException exception)
                {
                    Console.WriteLine(exception.Message);
                }
        }
    }
}