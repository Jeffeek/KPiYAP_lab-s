using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lab_no20
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            Console.Write("Введите число -1 < x < 1: ");
            var x = Double.Parse(Console.ReadLine());
            Console.Write("E = ");
            var E = Double.Parse(Console.ReadLine());
            Task.Run(() => Log10(x, E, token));
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.UpArrow)
                tokenSource.Cancel();

            Console.ReadLine();
        }

        private static async Task<double> Log10(double x, double precision, CancellationToken token)
        {
            var n = 1;
            var t = x;
            var s = t;
            while (MathBicycle.Abs(t) / n > precision)
            {
                Console.Clear();
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("До конца операция не выполнилась, но запрос остановить его всё таки пришёл..");

                    break;
                }

                n++;
                t = -t * x;
                s += t / n;
                Console.WriteLine($"{n} {t} {s}");
                await Task.Delay(2000);
            }

            return s;
        }
    }
}
