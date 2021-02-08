using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_no16._3
{
    public class Dog
    {
	    /// <inheritdoc />
	    public override string ToString() => $"{nameof(Name)}: {Name}, {nameof(Breed)}: {Breed}, {nameof(HouseType)}: {HouseType}, {nameof(Age)}: {Age}, {nameof(MasterName)}: {MasterName}";

	    public string Name { get; set; }
        public string Breed { get; set; }
        public string HouseType { get; set; }
        public int Age { get; set; }
        public string MasterName { get; set; }

    }
}
