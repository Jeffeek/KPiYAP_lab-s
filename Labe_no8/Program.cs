using System;
using System.IO;

namespace Labe_no8
{
    class Program
    {
        static void Main(string[] args)
        {
            DateRegex date = new DateRegex($"{Directory.GetCurrentDirectory()}\\timeregex.txt");
            var dates = date.GetResult();
            foreach (var d in dates)
                Console.WriteLine(d.ToShortDateString());
            HtmlRegex html = new HtmlRegex($"{Directory.GetCurrentDirectory()}\\htmlregex.txt");
            html.Parse();
            Console.ReadLine();
        }
    }
}
