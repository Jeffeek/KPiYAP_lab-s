using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace Lab_no16
{
    class Program
    {
        static void Main(string[] args)
        {
            Task1();
            Task2();
        }

        static void Task1()
        {
	        var M = new List<string>();
	        while (Console.ReadKey().Key != ConsoleKey.Spacebar)
	        {
		        Console.WriteLine("Введите значение: ");
		        var value = Console.ReadLine();
		        M.Add(value);
		        Console.Clear();
	        }
	        Console.WriteLine($"M : {String.Join(" ", M)}");
	        var M2 = M.AsEnumerable().Reverse();
	        Console.WriteLine($"M2 : {String.Join(" ", M2)}");
            var M1 = M.Concat(M2);
            Console.WriteLine($"M1 : {String.Join(" ", M1)}");
        }

        static void Task2()
        {
	        var infix = "A-B*B+C/D";
            var prefix = "*-A/BC-/AKL";
            var postfix = "ABC-+DE-FG-H+/*"; 

	        Console.WriteLine($"Infix -> Prefix : {infix} -> {FixConverter.InfixToPrefix(infix)}");
	        Console.WriteLine($"Infix -> Postfix : {infix} -> {FixConverter.InfixToPostfix(infix)}");
	        Console.WriteLine($"Prefix -> Infix : {prefix} -> {FixConverter.PrefixToInfix(prefix)}");
	        Console.WriteLine($"Postfix -> Infix : {postfix} -> {FixConverter.PostfixToInfix(postfix)}");
        }
    }
}
