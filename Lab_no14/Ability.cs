namespace Lab_no14
{
    public class Ability : IAbility
    {
        public Ability(string name, string subject)
        {
            Name = name;
            Subject = subject;
        }

        public string Name { get; }
        public string Subject { get; }
    }
}
