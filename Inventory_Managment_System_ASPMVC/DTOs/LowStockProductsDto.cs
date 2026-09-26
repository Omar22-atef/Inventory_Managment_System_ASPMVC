namespace Inventory_Managment_System_ASPMVC.DTOs
{
    public class LowStockProductsDto
    {
        public string ProductName { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
    }
}
