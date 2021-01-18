using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Lab_no15._2
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var game = LoadOrNew();
            var consoleLogger = new ConsoleLogger(game);
            StartGame(game);
            Console.ReadLine();
        }

        private static Queue<FeudalActions> GetActionsAtStep()
        {
            Console.ReadKey(false);
            var queue = new Queue<FeudalActions>();
            Console.WriteLine("Веберите Ваши действия для следующего шага: ");
            var isEndOfStep = false;
            while (!isEndOfStep)
            {
                Console.WriteLine("1. Увеличить налог");
                Console.WriteLine("2. Уменьшить налог");
                Console.WriteLine("3. Построить хижину");
                Console.WriteLine("4. Дать крестьянину свободу");
                Console.WriteLine("5. Провести пати-хард");
                Console.WriteLine("6. Закончить действия на этот шаг");
                int input;
                while (!int.TryParse(Console.ReadLine()?.Trim(), out input))
                    Console.WriteLine("Введи ещё раз, чукча");
                switch (input)
                {
                    case 1:
                        queue.Enqueue(FeudalActions.IncreaseTax);
                        break;
                    case 2:
                        queue.Enqueue(FeudalActions.ReduceTax);
                        break;
                    case 3:
                        queue.Enqueue(FeudalActions.BuildShack);
                        break;
                    case 4:
                        queue.Enqueue(FeudalActions.GiveFreeRein);
                        break;
                    case 5:
                        queue.Enqueue(FeudalActions.HoldCelebration);
                        break;
                    case 6:
                        isEndOfStep = true;
                        break;
                }
            }
            return queue;
        }

        private static void StartGame(FeudalGameEngine gameObject)
        {
            while (gameObject.IsGameOn)
            {
                var actions = GetActionsAtStep();
                if (actions.Count == 0) continue;
                gameObject.MakeStep(actions);
                SaveGame(gameObject);
            }

            Process.GetCurrentProcess().CloseMainWindow();
        }

        private static FeudalGameEngine LoadOrNew()
        {
            Console.WriteLine("Хотите загрузить игру? \n1. Да 2.Нет");
            var answer = int.Parse(Console.ReadLine() ?? string.Empty);
            switch (answer)
            {
                case 1:
                    {
                        var serializer = new DataContractJsonSerializer(typeof(DTOGameSave));
                        using var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}\\save.json", FileMode.Open);
                        var dto = serializer.ReadObject(fileStream) as DTOGameSave;
                        return new FeudalGameEngine(dto);
                    }

                case 2:
                    {
                        Console.WriteLine("Какое количество крестьян Вас устроит, милорд?");
                        var targetCount = int.Parse(Console.ReadLine());
                        Console.WriteLine("Какое количество крестьян будет у вас во владении с начала, милорд?");
                        var startCount = int.Parse(Console.ReadLine());
                        return new FeudalGameEngine(targetCount, startCount);
                    }

                default:
                    throw new ArgumentException(nameof(answer));
            }
        }

        private static void SaveGame(FeudalGameEngine game)
        {
            var dto = new DTOGameSave()
            {
                Money = game.Money,
                PeasantsCount = game.PeasantsCount,
                Settings = new DTOGameSettingsSave()
                {
                    MaxPeasantCount = game.Settings.MaxPeasantCount,
                    PeasantsTargetCount = game.Settings.PeasantsTargetCount,
                    PeasantSpawnChance = game.Settings.PeasantSpawnChance
                }
            };
            var serializer = new DataContractJsonSerializer(typeof(DTOGameSave));
            using var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}\\save.json", FileMode.Truncate);
            serializer.WriteObject(fileStream, dto);
        }
    }
}
