﻿#region Using namespaces

using System.Runtime.Serialization;

#endregion

namespace Lab_no15._3
{
    [DataContract]
    public class Human
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int Age { get; set; }

        [DataMember]
        public Address Address { get; set; }
    }
}