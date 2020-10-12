using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Additinal_after5.Models
{
    class Runner
    {
        private List<Student> _students;

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
            if (int.TryParse(Console.ReadLine(), out int answer))
            {
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
            }
            Menu();
        }

        private void FindSuperStudents()
        {
            Console.WriteLine("Введите балл, выше которого надо искать студентов: ");
            if (int.TryParse(Console.ReadLine(), out int mark))
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
            string group = GetGroup();
            var collection = _students.FindAll(x => x.GroupName == group);
            PrintStudents(collection);
        }

        private void FindStudentBySurname()
        {
            string surname = GetSurname();
            var collection = _students.FindAll(x => x.Surname == surname);
            if (collection.Count > 1)
            {
                Console.WriteLine("Нашли несколько студентов с такой фамилией");
            }
            PrintStudents(collection);
        }

        private void Exit()
        {
            Process.GetCurrentProcess().CloseMainWindow();
        }

        private void PrintStudents(IEnumerable<Student> list)
        {
            foreach (var s in list)
                Console.WriteLine(s);
        }

        private void RemoveStudent()
        {
            string surname = GetSurname();
            var student = _students.Find(x => x.Surname == surname);
            if (student == null)
                Console.WriteLine("Такого студента нет");
            _students.Remove(student);
        }

        private void AddStudent()
        {
            string surname = GetSurname();
            string name = GetName();
            string groupName = GetGroup();
            var marks = GetMarks();
            var student = new Student()
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
            string surname = Console.ReadLine();
            return surname;
        }

        private string GetName()
        {
            Console.WriteLine("Введите Имя студента: ");
            string name = Console.ReadLine();
            return name;
        }

        private string GetGroup()
        {
            Console.WriteLine("Введите номер группы студента: ");
            string groupname = Console.ReadLine();
            return groupname;
        }

        private int[] GetMarks()
        {
            Console.WriteLine("Введите оценки через пробел: ");
            string strMarks = Console.ReadLine();
            var marks = strMarks?.Split().Select(int.Parse);
            if (marks.Count() != 5)
                throw new Exception("дэбил ти шо");
            return marks.ToArray();
        }
    }
}
