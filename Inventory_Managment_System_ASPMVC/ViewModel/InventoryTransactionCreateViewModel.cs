using System.ComponentModel.DataAnnotations;
using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Models.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class InventoryTransactionCreateViewModel
    {
        public int ProductId { get; set; }
        [Required]
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
        public IEnumerable<SelectListItem>? Products{ get; set; }
        public InventoryTransactionType Type { get; set; }

    }
}
