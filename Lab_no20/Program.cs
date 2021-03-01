using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_no20
{
    class Program
    {
        public static double Power(double num, int power)
        {
            var result = num;

            while (power > 0)
            {
                result *= num;
                power--;
            }

            return result;
        }

        public static void Shit(int x, int delta)
        {
            double power = 1;
            var i = 2;
            var kol = 1;

            while (power.ToString().Length - 3 < delta)
            {
                Console.WriteLine(power);

                if (kol % 2 == 1)
                    power -= Power(x, i) / i;
                else
                    power += Power(x, i) / i;

                i++;
                kol++;
                var progress = (double)(power.ToString().Length - 3) / delta * 100;
                Console.WriteLine($"Прогресс: {progress}");
                Thread.Sleep(1000);
            }

            Console.WriteLine(power);
        }

        static void Main(string[] args)
        {
            var task = new Task(() => Shit(2, 3));
            task.Start();
            Console.ReadKey();
        }
    }
}
