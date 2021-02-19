#region Using derectives

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Lab_no15
{
	internal class Program
	{
		private static readonly string _loadFilePath1 = Path.Combine(Directory.GetCurrentDirectory(), "input1.txt");
		private static readonly string _loadFilePath2 = Path.Combine(Directory.GetCurrentDirectory(), "input2.txt");
		private static readonly string _outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "output1.txt");

		private static void Main(string[] args)
		{
			FirstTask();
			SecondTask();
		}

		private static void SecondTask()
		{
			var text = File.ReadAllText(_loadFilePath2);
			var sentences = text.Split(". ").Select(x => x + ". ");
			var ordered = sentences.SortByPunctuationAndSpaces().ToArray();
			foreach (var sentence in ordered) Console.WriteLine(sentence);
		}

		private static void FirstTask()
		{
			var text = File.ReadAllText(_loadFilePath1);
			var parsedMatrix = text.ParseJaggedMatrix();
			var resolvedArray = ResolveJaggedMatrix(parsedMatrix);
			File.WriteAllText(_outputFilePath, String.Join(" ", resolvedArray));
		}

		private static double[] ResolveJaggedMatrix(int[][] jaggedMatrix)
		{
			var list = new List<double>();
			var avg = jaggedMatrix.AvgInEachRow().ToArray();
			var minimalValues = jaggedMatrix.MinInEachRow().ToArray();
			var maximalValues = jaggedMatrix.MaxInEachRow().ToArray();
			var rowCount = avg.Length;
			for (var i = 0; i < rowCount; i++) list.Add(avg[i] * (minimalValues[i] + maximalValues[i]));

			return list.ToArray();
		}
	}
}