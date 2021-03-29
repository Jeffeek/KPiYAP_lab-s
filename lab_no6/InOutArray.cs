#region Using namespaces

using System;
using System.Linq;

#endregion

namespace lab_no6
{
    internal static class InOutArray
    {
        public static double[] GetArray(string line) => line.Split().Select(Double.Parse).ToArray();

        public static void PrintArray(double[] arr)
        {
            foreach (var d in arr) Console.WriteLine(d);
        }

        public static void PrintArray(double[] arr, string name, int countColumn)
        {
            Console.WriteLine($"{countColumn} : {name}");
            PrintArray(arr);
        }
    }
}