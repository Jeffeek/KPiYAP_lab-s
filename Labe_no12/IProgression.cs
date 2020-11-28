using System;
using System.Collections.Generic;
using System.Text;

namespace Labe_no12
{
    public interface IProgression
    {
        public double Q { get; }
        public double StartPoint { get; }
        double Sum(long n);
        double Get(long n);
    }
}
