using System.Runtime.Serialization;

namespace Lab_no15._2
{
	[DataContract]
    public class DTOGameSave
    {
	    [DataMember]
        public DTOGameSettingsSave Settings { get; set; }
	    [DataMember]
        public int Money { get; set; }
	    [DataMember]
        public int PeasantsCount { get; set; }
    }
}
