using System.ComponentModel.DataAnnotations;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class Supplier
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Address { get; set; }
        [Required]
        [StringLength(100)]
        public string City { get; set; }

        public bool IsDeleted { get; set; }
        public ICollection<InventoryTransaction>? InventoryTransactions { get; set; }
        
        public ICollection<ProductSuppliers> ProductSuppliers { get; set; } = new List<ProductSuppliers>();
    }
}
