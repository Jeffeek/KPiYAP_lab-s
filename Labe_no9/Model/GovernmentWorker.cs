using System.Collections.Generic;
using System.Linq;
using Labe_no9.Enums;

namespace Labe_no9.Model
{
    public class GovernmentWorker
    {
        private GovernmentBuilder _builder;
        private List<Government> _governments;

        public GovernmentWorker()
        {
            _builder = new GovernmentBuilder();
            _governments = new List<Government>();
        }

        public void AddGovernment(GovernmentType type, string name, string capital, long population, long area)
        {
            var item = _builder
                                .SetArea(area)
                                .SetCapital(capital)
                                .SetName(name)
                                .SetPopulation(population)
                                .SetCapital(capital)
                                .SetType(type)
                                .Build();
            _governments.Add(item);
        }

        public IEnumerable<Government> GetCollection() => _governments.AsEnumerable();

        public void RemoveGovernment(string name)
        {
            var item = _governments.SingleOrDefault(x => x.Name == name);
            _governments.Remove(item);
        }
    }
}
