using System.Collections.Generic;

namespace Labe_no11
{
    public class ModulOfThreeComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            int modX = x % 3;
            int modY = y % 3;
            return modX == modY ? x.CompareTo(y) : modX.CompareTo(modY);
        }
    }
}
