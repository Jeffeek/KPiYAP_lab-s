#region Using derectives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

#endregion

namespace Lab_no19
{
	public sealed class ConcurrentCalculation
	{
		private readonly int _t1;
		private readonly int _t2;

		private readonly ConcurrentFile _concurrentInputFile;
		private readonly ConcurrentFile _concurrentOutputFile;
		private InputOutputProvider _provider;

		public ConcurrentCalculation(string inputPath,
									 string outputPath,
									 int t1,
									 int t2,
									 InputOutputProvider provider
		)
		{
			_concurrentInputFile = new ConcurrentFile(inputPath);
			_concurrentOutputFile = new ConcurrentFile(outputPath);
			_provider = provider ?? throw new ArgumentNullException(nameof(provider));
			_t1 = t1;
			_t2 = t2;
			File.WriteAllText(outputPath, String.Empty);
		}

		public void StartCalculation1()
		{
			var threads = new List<Thread>();

			for (var i = 0; i < 5; i++) threads.Add(new Thread(DoWork1));

			threads.ForEach(x =>
							{
								x.Start();
								x.Join(TimeSpan.FromMilliseconds(_t1));
							});
		}

		public void StartCalculation2()
		{
			var threads = new List<Thread>();

			for (var i = 0; i < 5; i++) threads.Add(new Thread(DoWork2));

			threads.ForEach(x =>
							{
								x.Start();
								x.Join(TimeSpan.FromMilliseconds(_t2));
							});
		}

		private void DoWork2()
		{
			_concurrentOutputFile.Read()
								 .Split(Environment.NewLine)
								 .ToList()
								 .ForEach(str =>
										  {
											  Thread.Sleep(TimeSpan.FromMilliseconds(_t2));
											  _concurrentOutputFile.Write($"Делегат {str}");
										  });
		}

		private void DoWork1()
		{
			var result = _concurrentInputFile.Read();
			var lineLength = result.Length;

			var sum = 0;

			for (var i = 0; i < lineLength; i++)
			{
				Thread.Sleep(TimeSpan.FromMilliseconds(_t1));
				var digit = Int32.Parse(result[i].ToString());

				if (digit % 2 == 0) sum += digit;

				_concurrentOutputFile.Write($"Время: {DateTime.Now}\t"
											+ $"Процент выполнения: {Math.Round((i + 1) / (double)lineLength * 100, 0)}%\t"
											+ $"Решение Lab_no19\tРезультат: {sum}");
			}
		}
	}
}