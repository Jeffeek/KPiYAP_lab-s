#region Using namespaces

using System;

#endregion

namespace Labe_no10.Second_Task
{
    public abstract class Student
    {
        protected const int TotalCLasses = 20;

        protected Student(string fullName, int visitedClasses)
        {
            if (String.IsNullOrEmpty(fullName)) throw new ArgumentException(nameof(fullName));
            if (visitedClasses > TotalCLasses)
                throw new ArgumentException("Visited Classes count can't be more than Total", nameof(visitedClasses));
            FullName = fullName;
            VisitedClasses = visitedClasses;
        }

        public string FullName { get; }

        public int VisitedClasses { get; }

        public override string ToString() =>
            $"{nameof(FullName)}: {FullName}, {nameof(VisitedClasses)}: {VisitedClasses} / {TotalCLasses}";

        public abstract bool PassOffset();
    }
}