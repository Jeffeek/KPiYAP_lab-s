using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6
{
    static class Helper
    {
        public static double FindMax(double[] arr) => arr.Max();
        public static double FindMin(double[] arr) => arr.Min();

        public static void Sort(double[] arr, bool order)
        {
            if (order)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i; j < arr.Length; j++)
                    {
                        if (arr[i] < arr[j])
                        {
                            double temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    for (int j = i; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            double temp = arr[i];
                            arr[i] = arr[j];
                            arr[j] = temp;
                        }
                    }
                }
            }
        }

        public static double[] Mul(double[,] matrix, double[] vector)
        {
            return MatrixToVector(Mul(matrix, VectorToMatrix(vector)));
        }

        public static double[] MatrixToVector(double[,] matrix)
        {
            double[] vector = new double[matrix.GetLength(0)];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = matrix[i, 0];
            }

            return vector;
        }

        public static double[,] VectorToMatrix(double[] vector)
        {
            double[,] matrix = new double[vector.Length,1];
            for (int i = 0; i < vector.Length; i++)
                matrix[i, 0] = vector[i];
            return matrix;
        }

        public static double[,] Mul(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.ColumnsCount() != matrixB.RowsCount())
            {
                throw new Exception(
                    "Умножение не возможно! Количество столбцов первой матрицы не равно количеству строк второй матрицы.");
            }

            var matrixC = new double[matrixA.RowsCount(), matrixB.ColumnsCount()];

            for (var i = 0; i < matrixA.RowsCount(); i++)
            {
                for (var j = 0; j < matrixB.ColumnsCount(); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.ColumnsCount(); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return matrixC;
        }
    }
}
