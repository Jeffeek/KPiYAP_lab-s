using System;

namespace Lab_no14
{
    public class Match
    {
        private IHero _currentHero;
        private IHero _currentBeatenHero;
        private bool _abilityUsed = false;

        public Match(IHero firstHero, IHero secondHero)
        {
            FirstHero = firstHero;
            SecondHero = secondHero;
            _currentHero = firstHero;
            _currentBeatenHero = secondHero;
        }

        public IHero FirstHero { get; }
        public IHero SecondHero { get; }
        public IHero Winner { get; private set; }

        public void Start()
        {
            FirstHero.AbilityUsed += HeroAbilityUsedEventHandler;
            FirstHero.HeroDied += HeroDiedEventHandler;
            SecondHero.AbilityUsed += HeroAbilityUsedEventHandler;
            SecondHero.HeroDied += HeroDiedEventHandler;
            while (FirstHero.Life > 0 && SecondHero.Life > 0)
            {
                _abilityUsed = false;
                var punch = _currentHero.Punch(_currentBeatenHero);
                if (_abilityUsed)
                    continue;
                if (_currentHero == FirstHero)
                {
                    _currentHero = SecondHero;
                    _currentBeatenHero = FirstHero;
                }
                else
                {
                    _currentHero = FirstHero;
                    _currentBeatenHero = SecondHero;
                }
            }
        }

        private void HeroAbilityUsedEventHandler(object? sender, IAbility ability)
        {
            if (sender is IHero)
            {
                _abilityUsed = true;
                Console.WriteLine($"Герой использовал абилку: {ability.Name} : {ability.Subject}");
            }
        }

        private void HeroDiedEventHandler(object? sender, EventArgs args)
        {
            if (sender is IHero hero)
            {
                if (hero == FirstHero)
                {
                    Winner = SecondHero;
                    Console.WriteLine("Выиграл второй игрок!");
                }
                else
                {
                    Winner = FirstHero;
                    Console.WriteLine("Выиграл первый игрок!");
                }
            }
        }
    }
}
