using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6
{
    class InOutArray
    {
        public static double[] GetArray(string line)
        {
            return line.Split().Select(double.Parse).ToArray();
        }

        public static void PrintArray(double[] arr)
        {
            foreach (var d in arr)
                Console.WriteLine(d);
        }

        public static void PrintArray(double[] arr, string name, int countColumn)
        {
            Console.WriteLine($"{countColumn} : {name}");
            PrintArray(arr);
        }
    }
}
