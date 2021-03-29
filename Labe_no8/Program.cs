#region Using namespaces

using System;
using System.IO;

#endregion

namespace Labe_no8
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var date = new DateRegex($"{Directory.GetCurrentDirectory()}\\timeregex.txt");
            var dates = date.GetResult();
            foreach (var d in dates) Console.WriteLine(d.ToShortDateString());
            var html = new HtmlRegex($"{Directory.GetCurrentDirectory()}\\htmlregex.txt");
            html.Parse();
            Console.ReadLine();
        }
    }
}