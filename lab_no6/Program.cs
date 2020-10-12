using System;
using System.Linq;
using System.Linq.Expressions;

namespace lab_no6
{
    class Program
    {
        static void Main(string[] args)
        {
            MatrixWorkTask();
            //double[] vat = new double[5] {1,7,2,10,13};
            //Helper.Sort(vat, true);
            //InOutArray.PrintArray(vat);
            //Console.WriteLine(new string('-', 15));
            //Helper.Sort(vat, false);
            //InOutArray.PrintArray(vat);
            //1.
            WeatherTask();

            //2.
            StudentTask();

            //3.
            ArrayEqualityTask();

            //4.
            MatrixWorkTask();

            Console.ReadLine();
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
    }
}
