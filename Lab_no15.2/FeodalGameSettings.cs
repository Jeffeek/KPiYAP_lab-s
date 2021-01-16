using System.Runtime.Serialization;

namespace Lab_no15._2
{
    [DataContract]
    public class FeodalGameSettings
    {
	    [DataMember]
	    public double PeasentSpawnChance { get; set; } = 0.3;
	    [DataMember]
	    public int MaxPeasentCount { get; set; } = 10;
	    [DataMember]
	    public int PeasantsTargetCount { get; }
	    
	    //for new game
	    public FeodalGameSettings(int peasantsTargetCount)
	    {
		    PeasantsTargetCount = peasantsTargetCount;
	    }

	    //for load
	    public FeodalGameSettings(DTOGameSettingsSave dto)
	    {
		    PeasentSpawnChance = dto.PeasentSpawnChance;
		    MaxPeasentCount = dto.MaxPeasentCount;
		    PeasantsTargetCount = dto.PeasantsTargetCount;
	    }
    }
}
