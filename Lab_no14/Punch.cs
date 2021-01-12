namespace Lab_no14
{
    public class Punch : IPunch
    {
        public Punch(int strength, IHero @from, IHero to)
        {
            Strength = strength;
            From = @from;
            To = to;
            To.Life -= strength;
        }

        public int Strength { get; }
        public IHero From { get; }
        public IHero To { get; }
    }
}
