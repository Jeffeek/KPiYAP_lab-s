using System;

namespace Labe_no10.Second_Task
{
    public abstract class Student
    {
        public override string ToString()
        {
            return $"{nameof(FullName)}: {FullName}, {nameof(VisitedClasses)}: {VisitedClasses} / {TotalCLasses}";
        }

        protected const int TotalCLasses = 20;
        public string FullName { get; }
        public int VisitedClasses { get; }

        public abstract bool PassOffset();

        protected Student(string fullName, int visitedClasses)
        {
            if (String.IsNullOrEmpty(fullName)) throw new ArgumentException(nameof(fullName));
            if (visitedClasses > TotalCLasses) throw new ArgumentException("Visited Classes count can't be more than Total", nameof(visitedClasses));
            FullName = fullName;
            VisitedClasses = visitedClasses;
        }
    }
}
