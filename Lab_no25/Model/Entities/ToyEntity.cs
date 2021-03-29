#region Using namespaces

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Lab_no25.Model.Entities
{
    [Index(nameof(Id))]
    public class ToyEntity
    {
        private decimal _price;

        [Required]
        [Key]
        public uint Id { get; set; }

        [Required]
        public string Producer { get; set; }

        [DefaultValue(typeof(decimal), "0,0")]
        [Required]
        public decimal Price
        {
            get => _price;
            set => _price = Math.Round(value, 2);
        }

        [DefaultValue(typeof(decimal), "0,0")]
        [Required]
        public uint WarehouseCount { get; set; }

        [Required]
        public string Photo { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ToyCategoryEntity Category { get; set; }

        [Required]
        public uint CategoryId { get; set; }

        public ICollection<SaleEntity> Sales { get; set; }

        public override string ToString() =>
            $"{nameof(Id)}: {Id}, {nameof(Producer)}: {Producer}, {nameof(Price)}: {Price}, {nameof(WarehouseCount)}: {WarehouseCount}, {nameof(Photo)}: {Photo}, {nameof(Category)}: {Category}, {nameof(CategoryId)}: {CategoryId}";
    }
}