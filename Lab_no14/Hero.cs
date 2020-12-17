using System;

namespace Lab_no14
{
    public class Hero : IHero
    {
        private int _life;

        public Hero(int life, double abilityPossibility, IAbility ability, int minPunch, int maxPunch)
        {
            Life = life;
            AbilityPossibility = abilityPossibility;
            Ability = ability;
            MinPunch = minPunch;
            MaxPunch = maxPunch;
        }

        public int Life
        {
            get => _life;
            set
            {
                _life = value;
                if (_life <= 0)
                    HeroDied?.Invoke(this, EventArgs.Empty);
            }
        }

        public double AbilityPossibility { get; }
        public IAbility Ability { get; }

        public int MinPunch { get; }
        public int MaxPunch { get; }

        public IPunch Punch(IHero to)
        {
            var rnd = new Random();
            int punchStrength = rnd.Next(MinPunch, MaxPunch + 1);
            double ability = rnd.NextDouble();
            if (ability <= AbilityPossibility)
                AbilityUsed?.Invoke(this, Ability);
            IPunch punch = new Punch(punchStrength, this, to);
            HeroPunched?.Invoke(this, punch);
            return punch;
        }

        public event EventHandler<IPunch> HeroPunched;
        public event EventHandler HeroDied;
        public event EventHandler<IAbility> AbilityUsed;
    }
}
