using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_no19
{
    public sealed class ConcurrentCalculation
    {
	    private InputOutputProvider _provider;

	    private readonly int _t1;

	    private readonly ConcurrentFile _concurrentInputFile;
	    private readonly ConcurrentFile _concurrentOutputFile;

		public ConcurrentCalculation(string inputPath,
		                             string outputPath,
		                             int t1,
		                             InputOutputProvider provider)
		{
			_concurrentInputFile = new ConcurrentFile(inputPath);
			_concurrentOutputFile = new ConcurrentFile(outputPath);
			_provider = provider ?? throw new ArgumentNullException(nameof(provider));
			_t1 = t1;
			File.WriteAllText(outputPath, String.Empty);
		}

		public void StartCalculation()
		{
			var threads = new List<Thread>();
			for (var i = 0; i < 10; i++)
			{
				threads.Add(new Thread(DoWork1));
			}
			
			threads.ForEach(x =>
			                {
				                x.Start();
				                x.Join(TimeSpan.FromMilliseconds(_t1));
			                });
		}

		private void DoWork1()
		{
			Thread.Sleep(TimeSpan.FromSeconds(3));
			var result = _concurrentInputFile.Read()
			                                 .Select(x => int.Parse(x.ToString()))
			                                 .Where(x => x % 2 == 0)
			                                 .Sum();
			
			_concurrentOutputFile.Write($"Время: {DateTime.Now}\tПроцент выполнения: 100%\tРешение Lab_no19\tРезультат: {result}");
		}
    }
}
