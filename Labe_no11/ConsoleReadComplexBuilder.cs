#region Using namespaces

using System;

#endregion

namespace Labe_no11
{
    public class ConsoleReadComplexBuilder : ComplexNumberBuilder
    {
        public override Complex Build()
        {
            var real = TakeRealPart();
            var virt = TakeVirtualPart();
            var complex = new Complex(real, virt);

            return complex;
        }

        protected override double TakeRealPart()
        {
            Console.WriteLine("Введите действительную часть: ");

            if (Double.TryParse(Console.ReadLine(), out var real))
                return real;

            throw new ArgumentException();
        }

        protected override double TakeVirtualPart()
        {
            Console.WriteLine("Введите мнимую часть: ");

            if (Double.TryParse(Console.ReadLine(), out var virt))
                return virt;

            throw new ArgumentException();
        }
    }
}