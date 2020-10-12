using System;
using System.Linq;

namespace lab_no6
{
    class Program
    {
        static double[,] GetMatrixFromConsole(string name)
        {
            Console.Write("Количество строк матрицы {0}:    ", name);
            var n = int.Parse(Console.ReadLine());
            Console.Write("Количество столбцов матрицы {0}: ", name);
            var m = int.Parse(Console.ReadLine());

            var matrix = new double[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < m; j++)
                {
                    Console.Write("{0}[{1},{2}] = ", name, i, j);
                    matrix[i, j] = int.Parse(Console.ReadLine());
                }
            }

            return matrix;
        }


        static void PrintMatrix(double[,] matrix)
        {
            for (var i = 0; i < matrix.RowsCount(); i++)
            {
                for (var j = 0; j < matrix.ColumnsCount(); j++)
                {
                    Console.Write(matrix[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }

        static double[,] MatrixMultiplication(double[,] matrixA, double[,] matrixB)
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

        static void Main(string[] args)
        {
            var weather = new Weather();
            Console.WriteLine(weather.GetCountOfDaysLessAvg($"{Console.ReadLine()}"));

            Console.WriteLine("Введите оценки студента через пробел: ");
            string marks = Console.ReadLine();
            StudentAlgo algp = new StudentAlgo(marks.Split().Select(int.Parse).ToArray());
            var algorithm = algp.GetAlgo();
            foreach (var s in algorithm)
                Console.WriteLine(s);

            Console.WriteLine("Введите последовательность чисел через пробел: ");
            string arrstr = Console.ReadLine();
            var arr = arrstr.Split().Select(x => int.Parse(x.ToString()));
            var sorted = arr.OrderByDescending(x => x);

            if (arr.SequenceEqual(sorted))
                Console.WriteLine("Вы ввели числа в невозростающем порядке");

            var mat = GetMatrixFromConsole("piska");
            var mat2 = GetMatrixFromConsole("piska2");
            var mul = MatrixMultiplication(mat, mat2);
            PrintMatrix(mul);
            InOutArray.PrintArray(Helper.Mul(mat, new []{1.0,2.0}));

            Console.ReadLine();
        }
    }
}
