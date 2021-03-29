#region Using namespaces

using System;

#endregion

namespace Lab_no16._2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var set = new StrangeSet<int>();
            for (var i = 0; i < 10; i++) set.Add(i);

            set += 5;
            var remove = set - 5;

            Console.WriteLine();
        }
    }
}