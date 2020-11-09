using System;

namespace Labe_no10.Second_Task.Builder
{
    class StudentBuilder
    {
        private enum StudentType { Default, BrightHead, Genius }

        private StudentType _type;
        private string _fullName;
        private int _passedClasses;

        public Student Build()
        {
            switch (_type)
            {
                case StudentType.Default:
                {
                    return new DefaultStudent(_fullName, _passedClasses);
                }
                case StudentType.BrightHead:
                {
                    return new BrightHeadStudent(_fullName, _passedClasses);
                }
                case StudentType.Genius:
                {
                    return new GeniusStudent(_fullName, _passedClasses);
                }
            }
            throw new NotSupportedException();
        }

        public StudentBuilder SetFullName()
        {
            Console.WriteLine("Введите имя студента: ");
            string name = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(name))
            {
                _fullName = name;
                return this;
            }
            throw new NotSupportedException();
        }

        public StudentBuilder SetPassedClasses()
        {
            Console.WriteLine("Введите сколько занятий посетил студент: ");
            if (int.TryParse(Console.ReadLine(), out int passed))
            {
                _passedClasses = passed;
                return this;
            }
            throw new NotSupportedException();
        }

        public StudentBuilder SetCategory()
        {
            Console.WriteLine("Введите категорию студента(числом или названием): ");
            foreach(var type in Enum.GetNames(typeof(StudentType)))
                Console.WriteLine(type);
            if (Enum.TryParse(Console.ReadLine(), out StudentType studentType))
            {
                _type = studentType;
                return this;
            }

            _type = StudentType.Default;
            return this;
            //throw new NotSupportedException();
        }
    }
}
