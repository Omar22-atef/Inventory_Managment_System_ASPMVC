using Inventory_Managment_System_ASPMVC.DTOs;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public interface IDashboardService
    {
        int GetTotalProducts();

        int GetTotalSuppliers();

        int GetTotalCategories();

        decimal GetTotalStockCost();
        StockStatusDto GetStockStatus();
        IEnumerable<TopMoingProductsDto> GetTopMovingProducts(int count);
        IEnumerable<TopSuppliersDto> GetTopSuppliers(int count);
        IEnumerable<LowStockProductsDto> GetLowStockProducts();
        IEnumerable<RecentTransactionsDto> GetRecentTransactions(int count);
        IEnumerable<ProductsByCategoryDto> GetProductsByCategories();
        IEnumerable<TransactionTrendDto> GetTransactionTrends();
    }
}
