using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace lab_no6
{
    class Program
    {
        static void Main(string[] args)
        {
            TableMatrixTask();
            //Console.WriteLine("Star Task");
            //StarTask();
            //Console.WriteLine("Matrix Task");
            //MatrixWorkTask();
            //Console.WriteLine("Array Task");
            //ArrayWorkTask();
            ////1.
            //Console.WriteLine("Weather Task");
            //WeatherTask();
            //////2.
            //Console.WriteLine("Student Task");
            //StudentTask();
            //////3.
            //Console.WriteLine("ArrayEquality Task");
            //ArrayEqualityTask();
            Console.ReadLine();
        }

        static void ArrayWorkTask()
        {
            double[] vat = new double[5] { 1, 7, 2, 10, 13 };
            Helper.Sort(vat, true);
            InOutArray.PrintArray(vat);
            Console.WriteLine(new string('-', 15));
            Helper.Sort(vat, false);
            InOutArray.PrintArray(vat);
        }

        static void TableMatrixTask()
        {
            Matrix mat = new Matrix(3,3);
            mat.FillRandomly();
            var matrix = mat.InnerMatrix;
            var table = new TableMatrixModels.Table(matrix);
            Console.WriteLine(table.ToString());
        }

        static void WeatherTask()
        {
            var weather = new Weather();
            Console.WriteLine("Введите месяц на английском: ");
            Console.WriteLine(weather.GetCountOfDaysLessAvg($"{Console.ReadLine()}"));
        }

        static void StudentTask()
        {
            Console.WriteLine("Введите оценки студента через пробел: ");
            string marks = Console.ReadLine();
            Student algp = new Student(marks.Split().Select(int.Parse).ToArray());
            var algorithm = algp.GetMarks();
            foreach (var s in algorithm)
                Console.WriteLine(s);
        }

        static void ArrayEqualityTask()
        {
            Console.WriteLine("Введите последовательность чисел через пробел: ");
            string arrstr = Console.ReadLine();
            var arr = arrstr.Split().Select(x => int.Parse(x.ToString()));
            var sorted = arr.OrderByDescending(x => x);

            if (arr.SequenceEqual(sorted))
                Console.WriteLine("Вы ввели числа в невозростающем порядке");
        }

        static void MatrixWorkTask()
        {
            Console.WriteLine(new string('-', 15));
            var mat = new Matrix(2,2);
            mat.FillRandomly();
            var mat2 = new Matrix(2, 2);
            mat2.FillRandomly();
            var mulMatOnMat = Matrix.MatrixMultiplication(mat, mat2);
            Console.WriteLine(new string('-', 15));
            Console.WriteLine(mat);
            Console.WriteLine(new string('-', 15));
            Console.WriteLine(mat2);
            Console.WriteLine(new string('-', 15));
            Console.WriteLine(mulMatOnMat);
            Console.WriteLine(new string('-', 15));

            var vector = Helper.GetVectorFromConsole();
            var matrixOnVector = Matrix.MulVector(mat, vector);
            InOutArray.PrintArray(vector);
            Console.WriteLine(new string('-', 15));
            Console.WriteLine(matrixOnVector);
            Console.WriteLine(new string('-', 15));
        }

        static void StarTask()
        {
            var array = new double[31];
            var rnd = new Random();
            for (int i = 0; i < 31; i++)
                array[i] = rnd.Next(102, 354);
            var newArray = array.Where((x, y) => x * 0.1 > y).OrderBy(x => x).ToArray();
            Console.WriteLine("");
            Console.WriteLine(new string('-', 81));
            for (int i = 0; i < 31; i++)
            {
                if (i % 5 == 0 && i != 0)
                    Console.WriteLine('|');
                if (i >= 9)
                    Console.Write($"|M[{i + 1}]={array[i]}|\t");
                if (i < 9)
                    Console.Write($"|M[{i + 1}]={array[i]} |\t");
                if (i == 30)
                    Console.Write("\t\t\t\t\t\t\t\t|");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 81));
            for (int i = 0; i < newArray.Length; i++)
            {
                if (i % 5 == 0 && i != 0)
                    Console.WriteLine('|');
                if (i >= 9)
                    Console.Write($"|M[{i + 1}]={array[i]}|\t");
                if (i < 9)
                    Console.Write($"|M[{i + 1}]={array[i]} |\t");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 81));

            Console.WriteLine();
        }
    }
}
