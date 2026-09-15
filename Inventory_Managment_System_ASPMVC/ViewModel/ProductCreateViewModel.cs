using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class ProductCreateViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(300)]
        public string? Description { get; set; }
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
        public int CategoryId { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
    }
}
