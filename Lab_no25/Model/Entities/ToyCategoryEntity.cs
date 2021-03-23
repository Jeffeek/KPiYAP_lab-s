using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab_no25.Model.Entities
{
    [Index(nameof(Id))]
    public class ToyCategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Range(0, Int32.MaxValue)]
        [Required]
        public int WarrantyPeriod { get; set; }

        [Required]
        public string CareRules { get; set; }

        [Range(0, 1000)]
        [Required]
        public int Age { get; set; }
    }
}
