#region Using namespaces

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace Additinal_after5.Models
{
    internal class Runner
    {
        private readonly List<Student> _students;

        public Runner()
        {
            _students = new List<Student>();
            Menu();
        }

        private void Menu()
        {
            Console.WriteLine("1. Добавить студента");
            Console.WriteLine("2. Удалить студента");
            Console.WriteLine("3. Вывести всех студентов");
            Console.WriteLine("4. Вывести конкретного студента по фамилии");
            Console.WriteLine("5. Вывести всех студентов из конкретной группы");
            Console.WriteLine("6. Вывести студентов, у которых средний балл больше введенного критерия");
            Console.WriteLine("7. Вывести студентов, у которых три и более незачётов");
            Console.WriteLine("8. Выход");

            if (Int32.TryParse(Console.ReadLine(), out var answer))
                switch (answer)
                {
                    case 1:
                    {
                        AddStudent();

                        break;
                    }

                    case 2:
                    {
                        RemoveStudent();

                        break;
                    }

                    case 3:
                    {
                        PrintStudents(_students);

                        break;
                    }

                    case 4:
                    {
                        FindStudentBySurname();

                        break;
                    }

                    case 5:
                    {
                        FindStudentsByGroup();

                        break;
                    }

                    case 6:
                    {
                        FindSuperStudents();

                        break;
                    }

                    case 7:
                    {
                        FindAssHoles();

                        break;
                    }

                    case 8:
                    {
                        Exit();

                        break;
                    }
                }

            Menu();
        }

        private void FindSuperStudents()
        {
            Console.WriteLine("Введите балл, выше которого надо искать студентов: ");

            if (Int32.TryParse(Console.ReadLine(), out var mark))
            {
                var collection = _students.Where(x => x.Marks.Average() > mark);
                PrintStudents(collection);
            }
        }

        private void FindAssHoles()
        {
            var collection = _students.Where(x => x.Marks.Count(_ => _ < 4) >= 3);
            PrintStudents(collection);
        }

        private void FindStudentsByGroup()
        {
            var group = GetGroup();
            var collection = _students.FindAll(x => x.GroupName == group);
            PrintStudents(collection);
        }

        private void FindStudentBySurname()
        {
            var surname = GetSurname();
            var collection = _students.FindAll(x => x.Surname == surname);

            if (collection.Count > 1)
                Console.WriteLine("Нашли несколько студентов с такой фамилией");

            PrintStudents(collection);
        }

        private void Exit()
        {
            Process.GetCurrentProcess()
                   .CloseMainWindow();
        }

        private void PrintStudents(IEnumerable<Student> list)
        {
            foreach (var s in list)
                Console.WriteLine(s);
        }

        private void RemoveStudent()
        {
            var surname = GetSurname();
            var student = _students.Find(x => x.Surname == surname);

            if (student == null)
                Console.WriteLine("Такого студента нет");

            _students.Remove(student);
        }

        private void AddStudent()
        {
            var surname = GetSurname();
            var name = GetName();
            var groupName = GetGroup();
            var marks = GetMarks();

            var student = new Student
                          {
                              GroupName = groupName,
                              Name = name,
                              Surname = surname,
                              Marks = marks
                          };

            if (_students.SingleOrDefault(x => x.Equals(student)) == null)
                _students.Add(student);
            else
                Console.WriteLine("Такой студент уже есть");
        }

        private string GetSurname()
        {
            Console.WriteLine("Введите Фамилию студента: ");
            var surname = Console.ReadLine();

            return surname;
        }

        private string GetName()
        {
            Console.WriteLine("Введите Имя студента: ");
            var name = Console.ReadLine();

            return name;
        }

        private string GetGroup()
        {
            Console.WriteLine("Введите номер группы студента: ");
            var groupname = Console.ReadLine();

            return groupname;
        }

        private int[] GetMarks()
        {
            Console.WriteLine("Введите оценки через пробел: ");
            var strMarks = Console.ReadLine();

            var marks = strMarks?.Split()
                                .Select(Int32.Parse);

            if (marks.Count() != 5)
                throw new Exception("дэбил ти шо");

            return marks.ToArray();
        }
    }
}