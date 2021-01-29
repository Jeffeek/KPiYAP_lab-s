using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_no16._2
{
    public class StrangeSet<T> : HashSet<T>
    {
	    public int Length => Count;

	    public T this[int index]
	    {
		    get
		    {
			    if (index < 0 ||
			        index >= Length) throw new ArgumentException(nameof(index));
			    return this.ElementAt(index);
		    }
	    }

	    public static bool operator -(StrangeSet<T> set, int number)
	    {
		    if (set.Length < number) return false;
		    if (set.Length == number)
		    {
				set.Clear();
				return true;
		    }
		    var newItems = set.Take(set.Length - number).ToArray();
		    set.Clear();
		    foreach (var item in newItems)
			    set.Add(item);
		    return true;
	    }

		public static StrangeSet<T> operator +(StrangeSet<T> set, int number)
		{
			if (typeof(T).FullName != "System.Int32") throw new TypeAccessException(nameof(T));
			var newItems = set.Select(x => (dynamic) x + number).ToArray();
			set.Clear();
			foreach (var item in newItems)
				set.Add(item);

			return set;
		}
	}
}
