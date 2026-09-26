using Inventory_Managment_System_ASPMVC.Models.Enums;

namespace Inventory_Managment_System_ASPMVC.DTOs
{
    public class RecentTransactionsDto
    {
        public string ProductName { get; set; }
        public InventoryTransactionType Type { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
