

using System;

namespace lab_no6
{
    public class Matrix
    {
        public int RowsCount { get; }
        public int ColumnsCount { get; }
        public double[,] MatrixArray { get; private set; }

        public Matrix(int rowsCount, int columnsCount)
        {
            RowsCount = rowsCount;
            ColumnsCount = columnsCount;
            MatrixArray = new double[RowsCount,ColumnsCount];
        }

        public void FillRandomly()
        {
            var rnd = new Random();
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
            get => MatrixArray[row, column];
            set => MatrixArray[row, column] = value;
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

        public void InitializateMatrix(double[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException();
            if (matrix.GetLength(0) != RowsCount || matrix.GetLength(1) != ColumnsCount) throw new ArgumentException();
            for (int i = 0; i < RowsCount; i++)
            {
                for (int j = 0; j < ColumnsCount; j++)
                {
                    this[i, j] = matrix[i,j];
                }
            }
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
