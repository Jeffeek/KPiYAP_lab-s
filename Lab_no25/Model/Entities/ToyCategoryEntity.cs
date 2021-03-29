#region Using namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Lab_no25.Model.Entities
{
    [Index(nameof(Id))]
    public class ToyCategoryEntity
    {
        [Key]
        public uint Id { get; set; }

        [Range(0, Int32.MaxValue)]
        [Required]
        public uint WarrantyPeriod { get; set; }

        [Required]
        public string CareRules { get; set; }

        [Range(0, 1000)]
        [Required]
        public uint Age { get; set; }

        public ICollection<ToyEntity> Toys { get; set; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id}, {nameof(WarrantyPeriod)}: {WarrantyPeriod}, {nameof(CareRules)}: {CareRules}, {nameof(Age)}: {Age}";
    }
}