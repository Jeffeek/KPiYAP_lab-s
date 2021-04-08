#region Using namespaces

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#endregion

namespace Lab_no25.Model.Entities
{
    public class CustomerEntity
    {
        [Required]
        [Key]
        public uint Id { get; set; }

        [StringLength(100, MinimumLength = 5)]
        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public virtual ICollection<PreOrderEntity> PreOrders { get; set; }
    }
}