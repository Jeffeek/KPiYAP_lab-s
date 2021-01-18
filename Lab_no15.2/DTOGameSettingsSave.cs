using System.Runtime.Serialization;

namespace Lab_no15._2
{
    [DataContract]
    public class DTOGameSettingsSave
    {
        [DataMember]
        public double PeasantSpawnChance { get; set; }
        [DataMember]
        public int MaxPeasantCount { get; set; }
        [DataMember]
        public int PeasantsTargetCount { get; set; }
    }
}
