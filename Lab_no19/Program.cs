using System;
using System.IO;

namespace Lab_no19
{
    class Program
    {
        static void Main(string[] args)
        {
	        var calc = new ConcurrentCalculation($"{Directory.GetCurrentDirectory()}\\number.in.txt",
	                                             $"{Directory.GetCurrentDirectory()}\\state.out.txt", 400,
	                                             new InputOutputProvider(Console.ReadLine, Console.WriteLine));
	        calc.StartCalculation();
        }
    }
}
