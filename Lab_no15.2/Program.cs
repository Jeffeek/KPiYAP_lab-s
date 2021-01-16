using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lab_no15._2
{
    class Program
    {
	    static void Main(string[] args)
	    {
	        var game = LoadOrNew();
		    var logger = new ConsoleLogger(game);
	        StartGame(game);
	        Console.ReadLine();
        }

	    static Queue<FeodalActions> GetActionsAtStep()
		{
			Console.ReadKey(false);
	        var queue = new Queue<FeodalActions>();
	        Console.WriteLine("Веберите Ваши действия для следующего шага: ");
	        bool isEndOfStep = false;
	        while(!isEndOfStep)
	        {
		        Console.WriteLine("1. Увеличить налог");
		        Console.WriteLine("2. Уменьшить налог");
		        Console.WriteLine("3. Построить хижину");
		        Console.WriteLine("4. Дать крестьянину свободу");
		        Console.WriteLine("5. Провести пати-хард");
		        Console.WriteLine("6. Закончить действия на этот шаг");
		        var input = int.Parse(Console.ReadLine().Trim());
		        switch(input)
		        {
					case 1:
						queue.Enqueue(FeodalActions.IncreaseTax);
						break;
					case 2:
						queue.Enqueue(FeodalActions.ReduceTax);
						break;
					case 3:
						queue.Enqueue(FeodalActions.BuildShack);
						break;
					case 4:
						queue.Enqueue(FeodalActions.GiveFreeRein);
						break;
					case 5:
						queue.Enqueue(FeodalActions.HoldCelebration);
						break;
					case 6:
						isEndOfStep = true;
						break;
					default:
						throw new ArgumentException("Ввёл не то, брат");
		        }
	        }
	        return queue;
        }

        static void StartGame(FeodalGameEngine gameObject)
        {
	        while(gameObject.IsGameOn)
	        {
		        var actions = GetActionsAtStep();
		        if (actions.Count == 0) continue;
		        gameObject.MakeStep(actions);
		        SaveGame(gameObject);
	        }

	        Process.GetCurrentProcess().CloseMainWindow();
        }

        static FeodalGameEngine LoadOrNew()
        {
	        Console.WriteLine("Хотите загрузить игру? \n1. Да 2.Нет");
	        int answer = int.Parse(Console.ReadLine());
	        if(answer == 1)
	        {
		        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DTOGameSave));
		        using var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}\\save.json", FileMode.Open);
		        var dto = serializer.ReadObject(fileStream) as DTOGameSave;
		        return new FeodalGameEngine(dto);
	        }
	        else if (answer == 2)
	        {
				Console.WriteLine("Какое количество крестьян Вас устроит, милорд?");
				var targetCount = int.Parse(Console.ReadLine());
				Console.WriteLine("Какое количество крестьян будет у вас во владении с начала, милорд?");
				var startCount = int.Parse(Console.ReadLine());
				return new FeodalGameEngine(targetCount, startCount);
	        }

	        throw new ArgumentException(nameof(answer));
        }

        static void SaveGame(FeodalGameEngine game)
        {
	        var dto = new DTOGameSave()
	                  {
		                  Money = game.Money,
		                  PeasantsCount = game.PeasantsCount,
		                  Settings = new DTOGameSettingsSave()
		                             {
			                             MaxPeasentCount = game.Settings.MaxPeasentCount,
			                             PeasantsTargetCount = game.Settings.PeasantsTargetCount,
			                             PeasentSpawnChance = game.Settings.PeasentSpawnChance
		                             }
	                  };
	        DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DTOGameSave));
	        using var fileStream = new FileStream($"{Directory.GetCurrentDirectory()}\\save.json", FileMode.Truncate);
	        serializer.WriteObject(fileStream, dto);
		}
    }
}
