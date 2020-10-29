using Labe_no9.Enums;

namespace Labe_no9.Model
{
    public struct Government
    {
        public override string ToString()
        {
            return $"{nameof(Type)}: {Type}, {nameof(Name)}: {Name}, {nameof(Capital)}: {Capital}, {nameof(Population)}: {Population}, {nameof(Area)}: {Area}";
        }

        public Government(GovernmentType type, string name, string capital, long population, long area)
        {
            Type = type;
            Name = name;
            Capital = capital;
            Population = population;
            Area = area;
        }


        public GovernmentType Type { get; set; }
        public string Name { get;  set; }
        public string Capital { get;  set; }
        public long Population { get;  set; }
        public long Area { get; set; }


    }
}
