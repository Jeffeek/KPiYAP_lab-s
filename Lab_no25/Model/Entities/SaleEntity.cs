using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_no25.Model.Entities
{
	[Microsoft.EntityFrameworkCore.Index(nameof(Id))]
	public class SaleEntity
	{
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
