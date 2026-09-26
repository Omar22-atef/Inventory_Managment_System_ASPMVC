using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Models.Enums;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationContext _context;
        public DashboardRepository(ApplicationContext context)
        {
            _context = context;
        }

        public int GetTotalProducts()
        {
            return _context.Products.Count();
        }

        public int GetTotalSuppliers()
        {
            return _context.Suppliers.Count();
        }

        public int GetTotalCategories()
        {
            return _context.Categories.Count();
        }

        public decimal GetTotalStockCost()
        {
            return _context.Products.Sum(p => p.PurchasePrice * p.CurrentStock);
        }

        public StockStatusDto GetStockStatus()
        {
            return new StockStatusDto()
            {
                Normal = _context.Products.Count(p => p.CurrentStock > p.MinimumStock),
                LowStock = _context.Products.Count(p => p.CurrentStock <= p.MinimumStock && p.CurrentStock > 0),
                OutOfStock = _context.Products.Count(p => p.CurrentStock == 0)
            };
        }
        public IEnumerable<TopMoingProductsDto> GetTopMoingProducts(int count)
        {
            return _context.InventoryTransactions
                  .GroupBy(t => new
                  {
                      t.ProductId,
                      t.Product.Name
                  })
                  .Select(g => new TopMoingProductsDto
                  {
                      ProductName = g.Key.Name,
                      TotalQuantity = g.Sum(t => t.Quantity)
                  })
                  .OrderByDescending(o => o.TotalQuantity)
                  .Take(count)
                  .ToList();
        }

        public IEnumerable<LowStockProductsDto> GetLowStockProducts()
        {
            return _context.Products.Where(p => p.CurrentStock > 0 && p.CurrentStock <= p.MinimumStock)
                .Select(l => new LowStockProductsDto
                {
                    ProductName = l.Name,
                    CurrentStock = l.CurrentStock,
                    MinimumStock = l.MinimumStock,
                })
                .OrderBy(o => o.CurrentStock)
                .ToList();
        }

        public IEnumerable<TopSuppliersDto> GetTopSuppliers(int count)
        { 
            return _context.InventoryTransactions
                .Where(s => s.SupplierId != null && s.Type == Models.Enums.InventoryTransactionType.Purchase)
                .GroupBy(t=> new  
                {
                    t.SupplierId,
                    t.Supplier.Name
                })
                .Select(s => new TopSuppliersDto
                { 
                    SupplierName = s.Key.Name,
                    TotalQuantity = s.Sum(t => t.Quantity)
                })
                .OrderByDescending (o => o.TotalQuantity)
                .Take(count)
                .ToList();
        }

        public IEnumerable<RecentTransactionsDto> GetRecentTransactions(int count)
        {
            return _context.InventoryTransactions
                .Select(t => new RecentTransactionsDto
                {
                    ProductName = t.Product.Name,
                    Type = t.Type,
                    Quantity = t.Quantity,
                    Date = t.Date
                })
                .OrderByDescending(o => o.Date)
                .Take(count)
                .ToList();
        }
        public IEnumerable<ProductsByCategoryDto> GetProductsByCategories()
        {
            return _context.Products
               .GroupBy(p => new
               {
                   p.CategoryId,
                   p.category.Name,
               })
               .Select(g => new ProductsByCategoryDto
               {
                   CategoryName = g.Key.Name,
                   ProductsCount = g.Count()
               })
               .OrderByDescending(o => o.ProductsCount)
               .ToList();
        }
        public IEnumerable<TransactionTrendDto> GetTransactionTrends()
        {
            return _context.InventoryTransactions
                .GroupBy(t => t.Date.Date)
                .Select(g => new TransactionTrendDto
                {
                    Date = g.Key,

                    StockIn = g
                        .Where(t => t.Type == InventoryTransactionType.Purchase ||
                                    t.Type == InventoryTransactionType.Return ||
                                    t.Type == InventoryTransactionType.AdjustmentIncrease)
                        .Sum(t => t.Quantity),

                    StockOut = g
                        .Where(t => t.Type == InventoryTransactionType.Sale ||
                                    t.Type == InventoryTransactionType.AdjustmentDecrease)
                        .Sum(t => t.Quantity)
                })
                .OrderBy(x => x.Date)
                .Take(7)
                .ToList();
        }
    }
}
