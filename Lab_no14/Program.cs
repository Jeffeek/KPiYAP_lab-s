#region Using namespaces

using System;

#endregion

namespace Lab_no14
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int firstWinCount = 0, secondWinCount = 0;

            for (var i = 0; i < 50; i++)
            {
                var hero = new Hero(110, 0.1, new Ability("Заморозка", "Застынь!"), 12, 14);
                var hero2 = new Hero(150, 0.2, new Ability("Оглушение", "Оглушение!"), 5, 15);
                var match = new Match(hero, hero2);
                match.Start();

                if (match.Winner == hero)
                    firstWinCount++;
                else
                    secondWinCount++;
            }

            Console.WriteLine($"Первый выиграл: {firstWinCount}\n" + $"Второй выиграл: {secondWinCount}");

            Console.WriteLine(new string('-', 50));

            firstWinCount = 0;
            secondWinCount = 0;

            for (var i = 0; i < 50; i++)
            {
                var hero = new Hero(110, 0.1, new Ability("Заморозка", "Застынь!"), 12, 14);
                var hero2 = new Hero(150, 0.2, new Ability("Оглушение", "Оглушение!"), 5, 15);
                var match = new Match(hero2, hero);
                match.Start();

                if (match.Winner != hero)
                    firstWinCount++;
                else
                    secondWinCount++;
            }

            Console.WriteLine($"Первый выиграл: {firstWinCount}\n" + $"Второй выиграл: {secondWinCount}");

            Console.ReadLine();
        }
    }
}