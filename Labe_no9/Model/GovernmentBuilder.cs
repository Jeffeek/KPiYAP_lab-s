using Labe_no9.Enums;

namespace Labe_no9.Model
{
    public class GovernmentBuilder
    {
        private Government _government;

        public GovernmentBuilder()
        {
            _government = new Government();
        }

        public Government Build()
        {
            return _government;
        }

        public GovernmentBuilder SetName(string name)
        {
            _government.Name = name;
            return this;
        }

        public GovernmentBuilder SetCapital(string capital)
        {
            _government.Capital = capital;
            return this;
        }

        public GovernmentBuilder SetType(GovernmentType type)
        {
            _government.Type = type;
            return this;
        }

        public GovernmentBuilder SetArea(long area)
        {
            _government.Area = area;
            return this;
        }

        public GovernmentBuilder SetPopulation(long population)
        {
            _government.Population = population;
            return this;
        }
    }
}
