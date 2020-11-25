using System;
using System.Collections.Generic;
using Labe_no10.First_Task;
using Labe_no10.Second_Task;
using Labe_no10.Second_Task.Builder;

namespace Labe_no10
{
    class Program
    {
        static void Main(string[] args)
        {
            ComputersTask();
            Console.WriteLine(new string('-', 60));
            StudentsTask();
            Console.ReadLine();
        }


        static void ComputersTask()
        {
            var gamingPC = new PersonalComputer(3700, 8, 16384, 2000);
            var vedroPC = new PersonalComputer(1900, 2, 4096, 240);

            var gamingLaptop = new Notebook(200, 2900, 4, 16384, 1000);
            var vedroLaptop = new Notebook(300, 1400, 2048, 6144, 1000);


            Console.WriteLine(gamingPC);
            Console.WriteLine(vedroPC);

            Console.WriteLine(gamingLaptop);
            Console.WriteLine(vedroLaptop);
        }

        static void StudentsTask()
        {
            var students = new List<Student>();
            var builder = new StudentBuilder();
            while (true)
            {
                var student = builder
                                    .SetFullName()
                                    .SetPassedClasses()
                                    .SetCategory()
                                    .Build();
                students.Add(student);
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.S)
                    break;
            }

            foreach (var student in students)
            {
                Console.WriteLine(student);
                Console.WriteLine($"Is passed: {student.PassOffset()}");
            }
        }
    }
}
