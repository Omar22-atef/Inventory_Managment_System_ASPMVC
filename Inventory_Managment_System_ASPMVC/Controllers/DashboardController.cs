using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Services;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            StockStatusDto status = _dashboardService.GetStockStatus();

            var dashboardData = new DashboardViewModel
            {
                TotalProducts = _dashboardService.GetTotalProducts(),
                TotalSuppliers = _dashboardService.GetTotalSuppliers(),
                TotalCategories = _dashboardService.GetTotalCategories(),
                TotalStockCost = _dashboardService.GetTotalStockCost(),
                NormalStockProducts = status.Normal,
                LowStockProductsCount = status.LowStock,
                OutOfStockProducts = status.OutOfStock,
                TopMoingProducts = _dashboardService.GetTopMovingProducts(5),
                TopSuppliers = _dashboardService.GetTopSuppliers(5),
                LowStockProducts = _dashboardService.GetLowStockProducts(),
                RecentTransactions = _dashboardService.GetRecentTransactions(5),
                ProductsByCategory = _dashboardService.GetProductsByCategories(),
                TransactionTrends = _dashboardService.GetTransactionTrends()
            };
            return View("Index", dashboardData);
        }

        

    }
}
