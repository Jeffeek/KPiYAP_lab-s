using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Lab_no15._2
{
    class Program
    {
	    static void Main(string[] args)
        {
	        Console.WriteLine("Какое количество крестьян Вас устроит, милорд?");
	        var targetCount = int.Parse(Console.ReadLine());
	        Console.WriteLine("Какое количество крестьян будет у вас во владении с начала, милорд?");
	        var startCount = int.Parse(Console.ReadLine());
	        var game = new FeodalGameEngine(targetCount, startCount);
	        game.PeasentAdded += AddPeasantEventHandler;
	        game.PeasentRemoved += RemovePeasantEventHandler;
	        game.LostGame += LostTheGameEventHandler;
	        game.WinGame += WonTheGameEventHandler;
	        game.MoneyEarned += MoneyBalanceChangedEventHandler;
	        game.MoneySpended += MoneyBalanceChangedEventHandler;
	        StartGame(game);
	        Console.ReadLine();
        }
        
        static void AddPeasantEventHandler(object sender, EventArgs args)
        {
	        if(sender is FeodalGameEngine engine)
		        Console.WriteLine($"К нам поступление крестьянина! {engine.PeasantsCount} / {engine.PeasantsTargetCount}");
        }

        static void RemovePeasantEventHandler(object sender, EventArgs args)
        {
	        if (sender is FeodalGameEngine engine)
		        Console.WriteLine($"Плохие новости! Крестьянин ушёл! {engine.PeasantsCount} / {engine.PeasantsTargetCount}");
        }

		static void WonTheGameEventHandler(object sender, EventArgs args)
		{
			Console.WriteLine("Поздравляю! Вы выиграли");
		}

		static void LostTheGameEventHandler(object sender, EventArgs args)
		{
			Console.WriteLine("К сожалению вы проиграли!");
		}

		static void MoneyBalanceChangedEventHandler(object sender, EventArgs args)
		{
			if (sender is FeodalGameEngine engine)
				Console.WriteLine($"Ваша казна поменяла баланс! Баланс: {engine.Money}");
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
		        gameObject.MakeStep(actions);
	        }

	        Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
