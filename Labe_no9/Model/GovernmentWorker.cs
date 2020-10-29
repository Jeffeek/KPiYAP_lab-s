using System;
using System.Collections.Generic;
using System.Data;
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
            Fill();
        }

        private void Fill()
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                var item = _builder
                    .SetArea(rnd.Next(1000, 300000))
                    .SetPopulation(rnd.Next(50000, 900000))
                    .SetType((GovernmentType) rnd.Next(0, 7))
                    .SetName(Guid.NewGuid().ToString().Substring(0, 10))
                    .SetCapital(Guid.NewGuid().ToString().Substring(0, 6))
                    .Build();
                _governments.Add(item);
            }
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
