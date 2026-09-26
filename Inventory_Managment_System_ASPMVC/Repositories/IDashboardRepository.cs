using Inventory_Managment_System_ASPMVC.DTOs;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public interface IDashboardRepository
    {
        int GetTotalProducts();

        int GetTotalSuppliers();

        int GetTotalCategories();

        decimal GetTotalStockCost();
        StockStatusDto GetStockStatus();
        IEnumerable<TopMoingProductsDto> GetTopMoingProducts(int count);
        IEnumerable<TopSuppliersDto> GetTopSuppliers(int count);
        IEnumerable<LowStockProductsDto> GetLowStockProducts();
        IEnumerable<RecentTransactionsDto> GetRecentTransactions(int count);
        IEnumerable<ProductsByCategoryDto> GetProductsByCategories();
        IEnumerable<TransactionTrendDto> GetTransactionTrends();
    }
}
