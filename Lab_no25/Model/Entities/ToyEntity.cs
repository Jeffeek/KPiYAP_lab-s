using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_no25.Model.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Id))]
    public class ToyEntity
    {
        public override string ToString() => $"{nameof(Id)}: {Id}, {nameof(Producer)}: {Producer}, {nameof(Price)}: {Price}, {nameof(WarehouseCount)}: {WarehouseCount}, {nameof(Photo)}: {Photo}, {nameof(Category)}: {Category}, {nameof(CategoryId)}: {CategoryId}";

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Producer { get; set; }

        [DefaultValue(typeof(decimal), "0,0")]
        [Required]
        public decimal Price { get; set; }

        [DefaultValue(typeof(decimal), "0,0")]
        [Required]
        public int WarehouseCount { get; set; }

        [Required]
        public string Photo { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public ToyCategoryEntity Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ICollection<SaleEntity> Sales { get; set; }
    }
}
