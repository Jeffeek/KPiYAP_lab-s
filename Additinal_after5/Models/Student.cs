using System;

namespace Additinal_after5.Models
{
    public class Student : IComparable<Student>
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public int[] Marks { get; set; }

        public override string ToString()
        {
            return $"{nameof(Surname)}: {Surname}," +
                   $" {nameof(Name)}: {Name}," +
                   $" {nameof(GroupName)}: {GroupName}," +
                   $" {nameof(Marks)}: {string.Join(", ", Marks)}";
        }

        public int CompareTo(Student other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            var surnameComparison = string.Compare(Surname, other.Surname, StringComparison.Ordinal);
            if (surnameComparison != 0) return surnameComparison;
            var nameComparison = string.Compare(Name, other.Name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            return string.Compare(GroupName, other.GroupName, StringComparison.Ordinal);
        }
    }
}
