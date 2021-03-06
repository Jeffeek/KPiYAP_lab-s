﻿#region Using namespaces

using System;
using System.IO;
using System.Xml.Linq;

#endregion

namespace Lab_no18._2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var menu = new ShopMenu(new InputOutputProvider(Console.ReadLine,
                                                            Console.WriteLine),
                                    XDocument.Load($"{Directory.GetCurrentDirectory()}\\ComputerStore.xml"));

            menu.Start();
        }
    }
}