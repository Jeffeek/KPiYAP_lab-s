#region Using derectives

using System;
using System.ComponentModel.Design;
using System.IO;
using System.Threading.Channels;

#endregion

namespace Lab_no19
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var container = new ServiceContainer();

			container.AddService(typeof(InputOutputProvider), new InputOutputProvider(Console.ReadLine, Console.WriteLine));

			var calc = new ConcurrentCalculation($"{Directory.GetCurrentDirectory()}\\number.in.txt",
												 $"{Directory.GetCurrentDirectory()}\\state.out.txt",
												 400,
												 550,
												 new InputOutputProvider(Console.ReadLine, Console.WriteLine));

			calc.StartCalculation1();
			calc.StartCalculation2();
		}
	}
}