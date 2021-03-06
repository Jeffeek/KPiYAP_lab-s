﻿#region Using namespaces

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#endregion

namespace Lab_no25.Model.Entities
{
    [Index(nameof(Id))]
    public class SaleEntity
    {
        private decimal _saleSum;

        [Required]
        [Key]
        public uint Id { get; set; }

        [ForeignKey(nameof(ToyId))]
        public ToyEntity Toy { get; set; }

        [Required]
        public uint ToyId { get; set; }

        [DefaultValue(typeof(int), "0")]
        [Required]
        public uint SaleCount { get; set; }

        [DefaultValue(typeof(int), "0")]
        [Required]
        public uint Discount { get; set; }

        [Required]
        public DateTime SaleDate { get; set; }

        [Required]
        public decimal SaleSum
        {
            get => _saleSum;
            set => _saleSum = Math.Round(value, 2);
        }

        public override string ToString() =>
            $"{nameof(Id)}: {Id}, {nameof(ToyId)}: {ToyId}, {nameof(SaleCount)}: {SaleCount}, {nameof(Discount)}: {Discount}, {nameof(SaleDate)}: {SaleDate}, {nameof(SaleSum)}: {SaleSum}";
    }
}