#region Using namespaces

using System;

#endregion

namespace Labe_no11
{
    public class Complex : IComparable<Complex>
    {
        public Complex(double realPart, double virtualPart)
        {
            RealPart = realPart;
            VirtualPart = virtualPart;
        }

        public Complex() { }

        public double RealPart { get; set; }

        public double VirtualPart { get; set; }

        public int CompareTo(Complex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var realPartComparison = RealPart.CompareTo(other.RealPart);

            if (realPartComparison != 0) return realPartComparison;

            return VirtualPart.CompareTo(other.VirtualPart);
        }

        public override string ToString()
        {
            var ch = VirtualPart > 0 ? "+" : "";

            return $@"{RealPart:#.##}{ch}{VirtualPart}i";
        }
    }
}