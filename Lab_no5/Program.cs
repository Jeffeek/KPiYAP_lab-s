using System;
using Lab_no5.Exceptions;
using Lab_no5.Models;

namespace Lab_no5
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeVelosiped time = new TimeVelosiped();
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

        static void AddSeconds_test(TimeVelosiped time)
        {
            Console.WriteLine("Введите секунды (add)");
            if (int.TryParse(Console.ReadLine(), out int seconds))
            {
                time.AddSeconds(seconds);
            }
        }

        static void AddMinutes_test(TimeVelosiped time)
        {
            Console.WriteLine("Введите минуты (add)");
            if (int.TryParse(Console.ReadLine(), out int min))
            {
                time.AddMinutes(min);
            }
        }

        static void AddHours_test(TimeVelosiped time)
        {
            Console.WriteLine("Введите часы (add)");
            if (int.TryParse(Console.ReadLine(), out int hours))
            {
                time.AddHours(hours);
            }
        }

        static void TypeSeconds_Exception(TimeVelosiped time)
        {
            Console.WriteLine("Введите секунды (set)");
            if (int.TryParse(Console.ReadLine(), out int seconds))
            {
                try
                {
                    time.Seconds = seconds;
                }
                catch (TimeSecondException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        static void TypeMinutes_Exception(TimeVelosiped time)
        {
            Console.WriteLine("Введите минуты (set)");
            if (int.TryParse(Console.ReadLine(), out int min))
            {
                try
                {
                    time.Minutes = min;
                }
                catch (TimeMinuteException exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
        }

        static void TypeHours_Exception(TimeVelosiped time)
        {
            Console.WriteLine("Введите часы (set)");
            if (int.TryParse(Console.ReadLine(), out int hours))
            {
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
}
