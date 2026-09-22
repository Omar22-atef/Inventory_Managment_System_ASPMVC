using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory_Managment_System_ASPMVC.Models
{
    public class ProductSuppliers
    {
        [ForeignKey("Supplier")]
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
