using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string ?Description { get; set; }
        [Required]
        public string SKU { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal PurchasePrice { get; set; }
        [Required]
        [Range(0, double.MaxValue)]
        public decimal SellingPrice { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int CurrentStock { get; set; } = 0;
        [Range(0, int.MaxValue)]
        public int MinimumStock { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey("category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public ICollection<InventoryTransaction> InventoryTransactions { get; set; }
    }
}
