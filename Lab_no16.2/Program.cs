using System;

namespace Lab_no16._2
{
    class Program
    {
        static void Main(string[] args)
        {
	        var set = new StrangeSet<int>();
	        for (int i = 0; i < 10; i++)
	        {
		        set.Add(i);
	        }

	        set += 5;
	        var remove = set - 5;

	        Console.WriteLine();

        }
    }
}
