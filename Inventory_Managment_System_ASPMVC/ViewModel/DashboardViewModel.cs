using System.Collections;
using Inventory_Managment_System_ASPMVC.DTOs;

namespace Inventory_Managment_System_ASPMVC.ViewModel
{
    public class DashboardViewModel
    {
        public int TotalProducts { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalCategories { get; set; }
        public decimal TotalStockCost { get; set; }
        public int NormalStockProducts { get; set; }
        public int LowStockProductsCount { get; set; }
        public int OutOfStockProducts { get; set; }
        public int QuantityMoved { get; set; }
        public IEnumerable<TopMoingProductsDto> TopMoingProducts { get; set; } = Enumerable.Empty<TopMoingProductsDto>();
        public IEnumerable<TopSuppliersDto> TopSuppliers { get; set; } = Enumerable.Empty<TopSuppliersDto>();
        public IEnumerable<LowStockProductsDto> LowStockProducts { get; set; } = Enumerable.Empty<LowStockProductsDto>();
        public IEnumerable<RecentTransactionsDto> RecentTransactions { get; set; } = Enumerable.Empty<RecentTransactionsDto>();
        public IEnumerable<ProductsByCategoryDto> ProductsByCategory { get; set; } = Enumerable.Empty<ProductsByCategoryDto>();
        public IEnumerable<TransactionTrendDto> TransactionTrends { get; set; } = Enumerable.Empty<TransactionTrendDto>();
    }
}
