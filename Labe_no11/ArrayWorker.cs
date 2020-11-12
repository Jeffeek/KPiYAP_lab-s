using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labe_no11
{
    class ArrayWorker
    {
        public int[] GetArray()
        {
            Console.WriteLine("Сколько элементов создать?");
            int n = int.Parse(Console.ReadLine());
            var arr = new int[Math.Abs(n)];
            Console.WriteLine("Заполнить его 1. автоматически или 2. вручную?");
            n = int.Parse(Console.ReadLine());
            if (n == 1)
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    arr[i - 1] = i;
                }
            }

            if (n == 2)
            {
                for (int i = 1; i <= arr.Length; i++)
                {
                    Console.WriteLine($"Элемент[{i}]: ");
                    n = int.Parse(Console.ReadLine());
                    arr[i - 1] = n;
                }
            }

            return arr;
        }

        public void Sort(int[] arr) => Array.Sort(arr, new ModulOfThreeComparer());
        public void PrintArray(int[] array) => array.ToList().ForEach(Console.WriteLine);
    }
}
