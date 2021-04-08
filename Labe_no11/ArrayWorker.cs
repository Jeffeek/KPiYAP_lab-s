#region Using namespaces

using System;
using System.Linq;

#endregion

namespace Labe_no11
{
    internal class ArrayWorker
    {
        public int[] GetArray()
        {
            Console.WriteLine("Сколько элементов создать?");
            var n = Int32.Parse(Console.ReadLine());
            var arr = new int[Math.Abs(n)];
            Console.WriteLine("Заполнить его 1. автоматически или 2. вручную?");
            n = Int32.Parse(Console.ReadLine());

            if (n == 1)
                for (var i = 1; i <= arr.Length; i++)
                    arr[i - 1] = i;

            if (n == 2)
                for (var i = 1; i <= arr.Length; i++)
                {
                    Console.WriteLine($"Элемент[{i}]: ");
                    n = Int32.Parse(Console.ReadLine());
                    arr[i - 1] = n;
                }

            return arr;
        }

        public void Sort(int[] arr) =>
            Array.Sort(arr, new ModulOfThreeComparer());

        public void PrintArray(int[] array) =>
            array.ToList()
                 .ForEach(Console.WriteLine);
    }
}