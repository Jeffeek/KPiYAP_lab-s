#region Using derectives

using System.Collections.Generic;

#endregion

namespace Labe_no11
{
	public class ModulOfThreeComparer : IComparer<int>
	{
		public int Compare(int x, int y)
		{
			var modX = x % 3;
			var modY = y % 3;

			return modX == modY ? x.CompareTo(y) : modX.CompareTo(modY);
		}
	}
}