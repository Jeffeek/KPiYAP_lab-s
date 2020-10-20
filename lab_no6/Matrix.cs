using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace lab_no6
{
    public class Matrix
    {
        private readonly double[,] _matrixArray;
        public int RowsCount { get; }
        public int ColumnsCount { get; }

        public Matrix(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            _matrixArray = new double[RowsCount,ColumnsCount];
        }

        public double[,] InnerMatrix => _matrixArray;

        public void FillRandomly()
        {
            Thread.Sleep(5);
            var rnd = new Random(DateTime.UtcNow.Millisecond);
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    this[i, j] = rnd.Next(-100, 100);
                }
            }
        }

        public double this[int row, int column]
        {
            get
            {
                if (row >= RowsCount || column >= ColumnsCount)
                    return _matrixArray[RowsCount-1, ColumnsCount-1];
                if (row < 0 || column < 0)
                    return _matrixArray[RowsCount - Math.Abs(row) - 1, ColumnsCount - Math.Abs(column) - 1];
                return _matrixArray[row, column];
            }

            set
            {
                if (row >= RowsCount || column >= ColumnsCount) return;
                _matrixArray[row, column] = value;
            }
        }


        public string GetMatrixAsString()
        {
            string result = "";
            for (int i = 0; i < RowsCount; i++)
            {
                result += "\n";
                for (int j = 0; j < ColumnsCount; j++)
                {
                    result += $"{this[i, j]} | ";
                }
            }

            return result;
        }

        public static Matrix MatrixMultiplication(Matrix matrixA, Matrix matrixB)
        {
            if (matrixA.ColumnsCount != matrixB.RowsCount)
            {
                throw new Exception(
                    "Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var matrixC = new Matrix(matrixA.RowsCount, matrixB.ColumnsCount);

            for (var i = 0; i < matrixA.RowsCount; i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount; j++)
                {
                    matrixC[i, j] = 0.0;

                    for (var k = 0; k < matrixA.ColumnsCount; k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }

        public static Matrix MulVector(Matrix matrix, double[] vector)
        {
            return MatrixMultiplication(matrix, MatrixConvertor.VectorToMatrix(vector));
        }

        public override string ToString()
        {
            return GetMatrixAsString();
        }
    }
}
