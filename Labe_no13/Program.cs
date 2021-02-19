#region Using derectives

using System;

#endregion

namespace Labe_no13
{
	public delegate double MatrixOperation();

	internal class Program
	{
		private static void Main(string[] args)
		{
			var n = 10;
			var matrix = new Matrix(n, n);
			matrix.FillRandomly(0, 10);

			MatrixOperation operation = matrix.DiagonalSum;
			Console.WriteLine(operation());
			operation = matrix.AvgSum;
			Console.WriteLine(operation());
			operation = matrix.SumSaddlePoints;
			Console.WriteLine(operation());
			Console.WriteLine(matrix);

			Console.ReadKey();
		}
	}
}