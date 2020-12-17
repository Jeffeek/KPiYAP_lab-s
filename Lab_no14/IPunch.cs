using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_no14
{
    public interface IPunch
    {
        int Strength { get; }
        IHero From { get; } 
        IHero To { get; }
    }
}
