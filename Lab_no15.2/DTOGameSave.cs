#region Using namespaces

using System.Runtime.Serialization;

#endregion

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