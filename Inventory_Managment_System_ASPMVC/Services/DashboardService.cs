using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Repositories;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardService(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }

        public int GetTotalProducts()
        {
            return _dashboardRepository.GetTotalProducts();
        }

        public int GetTotalSuppliers()
        {
            return _dashboardRepository.GetTotalSuppliers();
        }

        public int GetTotalCategories()
        {
            return _dashboardRepository.GetTotalCategories();
        }

        public decimal GetTotalStockCost()
        {
            return _dashboardRepository.GetTotalStockCost();
        }

        public StockStatusDto GetStockStatus()
        { 
            return _dashboardRepository.GetStockStatus();
        }
        public IEnumerable<TopMoingProductsDto> GetTopMovingProducts(int count)
        { 
            return _dashboardRepository.GetTopMoingProducts(count);
        }
        public IEnumerable<TopSuppliersDto> GetTopSuppliers(int count)
        { 
            return _dashboardRepository.GetTopSuppliers(count);
        }
        public IEnumerable<LowStockProductsDto> GetLowStockProducts()
        { 
            return _dashboardRepository.GetLowStockProducts();
        }
        public IEnumerable<RecentTransactionsDto> GetRecentTransactions(int count)
        {
            return _dashboardRepository.GetRecentTransactions(count);
        }
        public IEnumerable<ProductsByCategoryDto> GetProductsByCategories()
        {
            return _dashboardRepository.GetProductsByCategories();
        }
        public IEnumerable<TransactionTrendDto> GetTransactionTrends()
        {
            return _dashboardRepository.GetTransactionTrends();
        }
    }
}
