using System;

namespace Labe_no11
{
    public class Complex : IComparable<Complex>
    {
        public double RealPart
        {
            get => _realPart;
            set => _realPart = value;
        }

        public double VirtualPart
        {
            get => _virtualPart;
            set => _virtualPart = value;
        }

        private double _realPart;
        private double _virtualPart;

       

        public Complex(double realPart, double virtualPart)
        {
            _realPart = realPart;
            _virtualPart = virtualPart;
        }

        public Complex()
        { }



        public int CompareTo(Complex other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var realPartComparison = _realPart.CompareTo(other._realPart);
            if (realPartComparison != 0) return realPartComparison;
            return _virtualPart.CompareTo(other._virtualPart);
        }

        public override string ToString()
        {
            string ch = _virtualPart > 0 ? "+" : "";
            return $@"{_realPart:#.##}{ch}{_virtualPart}i";
        } 
    }
}
