using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_no6
{
    class Student
    {
        private int[] _marks;
        public Student(int[] marks)
        {
            _marks = marks;
        }

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
