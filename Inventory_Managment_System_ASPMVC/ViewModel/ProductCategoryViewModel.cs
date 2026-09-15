namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int CurrentStock { get; set; }
        public int MinimumStock { get; set; }
        public string CategoryName { get; set; }
    }
}
