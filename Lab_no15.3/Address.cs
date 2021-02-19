#region Using derectives

using System.Runtime.Serialization;

#endregion

namespace Lab_no15._3
{
	[DataContract]
	public class Address
	{
		[DataMember]
		public string Street { get; set; }

		[DataMember]
		public int Number { get; set; }

		[DataMember]
		public int Room { get; set; }
	}
}