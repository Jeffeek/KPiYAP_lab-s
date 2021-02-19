#region Using derectives

using System;
using System.Linq;

#endregion

namespace lab_no6
{
	internal static class Helper
	{
		public static double FindMax(double[] arr) => arr.Max();

		public static double FindMin(double[] arr) => arr.Min();

		//пузырёк
		public static void Sort(double[] arr, bool order)
		{
			for (var i = 0; i < arr.Length; i++)
			{
				for (var j = i; j < arr.Length; j++)
				{
					if (order)
					{
						if (arr[i] < arr[j])
						{
							var temp = arr[i];
							arr[i] = arr[j];
							arr[j] = temp;
						}
					}
					else
					{
						if (arr[i] > arr[j])
						{
							var temp = arr[i];
							arr[i] = arr[j];
							arr[j] = temp;
						}
					}
				}
			}
		}

		public static Matrix GetMatrixFromConsole()
		{
			Console.Write("Количество строк матрицы: ");
			var n = Int32.Parse(Console.ReadLine());
			Console.Write("Количество столбцов матрицы: ");
			var m = Int32.Parse(Console.ReadLine());

			var matrix = new Matrix(n, m);

			for (var i = 0; i < n; i++)
			{
				for (var j = 0; j < m; j++)
				{
					Console.Write($"[{i},{j}] = ");
					matrix[i, j] = Double.Parse(Console.ReadLine());
				}
			}

			return matrix;
		}

		public static double[] GetVectorFromConsole()
		{
			Console.Write("Количество строк вектора: ");
			var n = Int32.Parse(Console.ReadLine());
			var vector = new double[n];

			for (var j = 0; j < n; j++)
			{
				Console.Write($"[{j}] = ");
				vector[j] = Double.Parse(Console.ReadLine());
			}

			return vector;
		}
	}
}