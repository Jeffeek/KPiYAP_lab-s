#region Using namespaces

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace Lab_no25.Model.Entities
{
    public class PreOrderEntity
    {
        [Key]
        [Required]
        public uint Id { get; set; }

        [Required]
        public uint CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }

        [Required]
        public uint ToyId { get; set; }

        [ForeignKey(nameof(ToyId))]
        public ToyEntity Toy { get; set; }

        [Required]
        public DateTime PreOrderDate { get; set; }

        [DefaultValue(false)]
        [Required]
        public bool IsDone { get; set; }
    }
}