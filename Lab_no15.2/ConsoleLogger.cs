using System;

namespace Lab_no15._2
{
    public class ConsoleLogger
    {
        private void AddPeasantEventHandler(object sender, EventArgs args)
        {
            if (sender is FeudalGameEngine engine)
                Console.WriteLine($"К нам поступление крестьянина! {engine.PeasantsCount} / {engine.Settings.PeasantsTargetCount}");
        }

        private void RemovePeasantEventHandler(object sender, EventArgs args)
        {
            if (sender is FeudalGameEngine engine)
                Console.WriteLine($"Плохие новости! Крестьянин ушёл! {engine.PeasantsCount} / {engine.Settings.PeasantsTargetCount}");
        }

        private void WonTheGameEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("Поздравляю! Вы выиграли");
        }

        private void LostTheGameEventHandler(object sender, EventArgs args)
        {
            Console.WriteLine("К сожалению вы проиграли!");
        }

        private void MoneyBalanceChangedEventHandler(object sender, EventArgs args)
        {
            if (sender is FeudalGameEngine engine)
                Console.WriteLine($"Ваша казна поменяла баланс! Баланс: {engine.Money}");
        }

        public ConsoleLogger(FeudalGameEngine game)
        {
            game.PeasantAdded += AddPeasantEventHandler;
            game.PeasantRemoved += RemovePeasantEventHandler;
            game.LostGame += LostTheGameEventHandler;
            game.WinGame += WonTheGameEventHandler;
            game.MoneyEarned += MoneyBalanceChangedEventHandler;
            game.MoneySpend += MoneyBalanceChangedEventHandler;
        }
    }
}
