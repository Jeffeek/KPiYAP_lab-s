#region Using derectives

using System;
using System.Threading;

#endregion

namespace lab_no6
{
	public class Matrix
	{
		public Matrix(int rowsCount, int columnsCount)
		{
			RowsCount = rowsCount;
			ColumnsCount = columnsCount;
			InnerMatrix = new double[RowsCount, ColumnsCount];
		}

		public int RowsCount { get; }

		public int ColumnsCount { get; }

		public double[,] InnerMatrix { get; }

		public double this[int row, int column]
		{
			get
			{
				if (row >= RowsCount
					|| column >= ColumnsCount)
					return InnerMatrix[RowsCount - 1, ColumnsCount - 1];

				if (row < 0
					|| column < 0)
					return InnerMatrix[RowsCount - Math.Abs(row) - 1, ColumnsCount - Math.Abs(column) - 1];

				return InnerMatrix[row, column];
			}

			set
			{
				if (row >= RowsCount
					|| column >= ColumnsCount)
					return;

				InnerMatrix[row, column] = value;
			}
		}

		public void FillRandomly()
		{
			Thread.Sleep(5);
			var rnd = new Random(DateTime.UtcNow.Millisecond);

			for (var i = 0; i < RowsCount; i++)
			{
				for (var j = 0; j < ColumnsCount; j++) this[i, j] = rnd.Next(-100, 100);
			}
		}

		public string GetMatrixAsString()
		{
			var result = "";

			for (var i = 0; i < RowsCount; i++)
			{
				result += "\n";
				for (var j = 0; j < ColumnsCount; j++) result += $"{this[i, j]} | ";
			}

			return result;
		}

		public static Matrix MatrixMultiplication(Matrix matrixA, Matrix matrixB)
		{
			if (matrixA.ColumnsCount != matrixB.RowsCount)
			{
				throw new Exception("Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
			}

			var matrixC = new Matrix(matrixA.RowsCount, matrixB.ColumnsCount);

			for (var i = 0; i < matrixA.RowsCount; i++)
			{
				for (var j = 0; j < matrixB.ColumnsCount; j++)
				{
					matrixC[i, j] = 0.0;

					for (var k = 0; k < matrixA.ColumnsCount; k++) matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
				}
			}

			return matrixC;
		}

		public static Matrix MulVector(Matrix matrix, double[] vector) => MatrixMultiplication(matrix, MatrixConvertor.VectorToMatrix(vector));

		public override string ToString() => GetMatrixAsString();
	}
}