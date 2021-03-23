﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_no25.Model.Entities
{
	[Microsoft.EntityFrameworkCore.Index(nameof(Id))]
	public class SaleEntity
	{
        public override string ToString() => $"{nameof(Id)}: {Id}, {nameof(Toy)}: {Toy}, {nameof(ToyId)}: {ToyId}, {nameof(SaleCount)}: {SaleCount}, {nameof(Discount)}: {Discount}, {nameof(SaleDate)}: {SaleDate}, {nameof(SaleSum)}: {SaleSum}";

        [Required]
		[Key]
		public int Id { get; set; }

		[ForeignKey(nameof(ToyId))]
		public ToyEntity Toy { get; set; }

		[Required]
		public int ToyId { get; set; }

		[DefaultValue(typeof(int), "0")]
		[Required]
		public int SaleCount { get; set; }

		[DefaultValue(typeof(int), "0")]
		[Required]
		public int Discount { get; set; }

		[Required]
		public DateTime SaleDate { get; set; }

		[Required]
		public decimal SaleSum { get; set; }
	}
}
