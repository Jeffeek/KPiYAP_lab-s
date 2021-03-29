#region Using namespaces

using System.Linq;

#endregion

namespace lab_no6
{
    internal class Student
    {
        private readonly int[] _marks;

        public Student(int[] marks) => _marks = marks;

        public int[] GetMarks()
        {
            var marks = _marks
                        .OrderByDescending(x => x == 10)
                        .ThenByDescending(x => x == 8)
                        .ThenByDescending(x => x == 6);

            return marks.ToArray();
        }
    }
}