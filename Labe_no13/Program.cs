using System;

namespace Labe_no13
{
    public delegate double MatrixOperation(); 
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            var matrix = new Matrix(n,n);
            matrix.FillRandomly(-50, 50);

            MatrixOperation operation = matrix.DiagonalSum;
            Console.WriteLine(operation());
            operation = matrix.Sum;
            Console.WriteLine(operation());
            operation = matrix.SumSaddlePoints;
            Console.WriteLine(operation());

            Console.ReadKey();
        }
    }
}
