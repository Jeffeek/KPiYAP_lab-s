using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab_no25.Model.Entities
{
    [Microsoft.EntityFrameworkCore.Index(nameof(Id))]
    public class ToyEntity
    {
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
    }
}
