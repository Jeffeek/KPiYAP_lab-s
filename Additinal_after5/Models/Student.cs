#region Using namespaces

using System;

#endregion

namespace Additinal_after5.Models
{
    public class Student : IComparable<Student>
    {
        public string Surname { get; set; }

        public string Name { get; set; }

        public string GroupName { get; set; }

        public int[] Marks { get; set; }

        public int CompareTo(Student other)
        {
            if (ReferenceEquals(this, other))
                return 0;

            if (ReferenceEquals(null, other))
                return 1;

            var surnameComparison = String.Compare(Surname, other.Surname, StringComparison.Ordinal);

            if (surnameComparison != 0)
                return surnameComparison;

            var nameComparison = String.Compare(Name, other.Name, StringComparison.Ordinal);

            if (nameComparison != 0)
                return nameComparison;

            return String.Compare(GroupName, other.GroupName, StringComparison.Ordinal);
        }

        public override string ToString() =>
            $"{nameof(Surname)}: {Surname},"
            + $" {nameof(Name)}: {Name},"
            + $" {nameof(GroupName)}: {GroupName},"
            + $" {nameof(Marks)}: {String.Join(", ", Marks)}";
    }
}