using System;

namespace Lab_no15._2
{
    public class ConsoleLogger
    {
	    public void AddPeasantEventHandler(object sender, EventArgs args)
	    {
		    if (sender is FeodalGameEngine engine)
			    Console.WriteLine($"К нам поступление крестьянина! {engine.PeasantsCount} / {engine.Settings.PeasantsTargetCount}");
	    }

	    public void RemovePeasantEventHandler(object sender, EventArgs args)
	    {
		    if (sender is FeodalGameEngine engine)
			    Console.WriteLine($"Плохие новости! Крестьянин ушёл! {engine.PeasantsCount} / {engine.Settings.PeasantsTargetCount}");
	    }

	    public void WonTheGameEventHandler(object sender, EventArgs args)
	    {
		    Console.WriteLine("Поздравляю! Вы выиграли");
	    }

	    public void LostTheGameEventHandler(object sender, EventArgs args)
	    {
		    Console.WriteLine("К сожалению вы проиграли!");
	    }

	    public void MoneyBalanceChangedEventHandler(object sender, EventArgs args)
	    {
		    if (sender is FeodalGameEngine engine)
			    Console.WriteLine($"Ваша казна поменяла баланс! Баланс: {engine.Money}");
	    }

	    public ConsoleLogger(FeodalGameEngine game)
	    {
			game.PeasentAdded += AddPeasantEventHandler;
			game.PeasentRemoved += RemovePeasantEventHandler;
			game.LostGame += LostTheGameEventHandler;
			game.WinGame += WonTheGameEventHandler;
			game.MoneyEarned += MoneyBalanceChangedEventHandler;
			game.MoneySpended += MoneyBalanceChangedEventHandler;
		}
	}
}
