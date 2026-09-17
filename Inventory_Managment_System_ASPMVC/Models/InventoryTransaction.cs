using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Inventory_Managment_System_ASPMVC.Models.Enums;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class InventoryTransaction
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        [Required]
        public InventoryTransactionType Type { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
