using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public class InventoryTransactionRepository : IInventoryTransactionRepository
    {
        private readonly ApplicationContext _context;
        public InventoryTransactionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public IEnumerable<InventoryTransaction> GetAll()
        { 
            return _context.InventoryTransactions.Include(i => i.Product).ToList();
        }

        public InventoryTransaction? GetById(int id)
        {
            return _context.InventoryTransactions.Include(i => i.Product).FirstOrDefault(i => i.Id == id);
        }

        public void Add(InventoryTransaction transaction)
        { 
            _context.InventoryTransactions.Add(transaction);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<InventoryTransaction> GetByProductId(int productId)
        { 
            return _context.InventoryTransactions.Where(i => i.ProductId == productId).Include(i => i.Product).ToList();
        }

        public IEnumerable<InventoryTransaction> GetByType(InventoryTransactionType type)
        { 
            return _context.InventoryTransactions.Where(i => i.Type == type).Include(i => i.Product).ToList();
        }

        public IEnumerable<InventoryTransaction> GetRecentTransactions(int count)
        { 
            return _context.InventoryTransactions.OrderByDescending(i => i.Date).Include(i => i.Product).Take(count).ToList();
        }

        public IEnumerable<InventoryTransaction> GetByDateRange(DateTime from, DateTime to)
        { 
            return _context.InventoryTransactions.Where(i => i.Date >= from && i.Date < to).Include(i => i.Product).ToList();
        }

    }
}
