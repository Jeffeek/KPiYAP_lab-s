using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Lab_no15._2
{
    [DataContract]
    public class DTOGameSettingsSave
    {
		[DataMember]
		public double PeasentSpawnChance { get; set; }
		[DataMember]
		public int MaxPeasentCount { get; set; }
		[DataMember]
		public int PeasantsTargetCount { get; set; }
	}
}
