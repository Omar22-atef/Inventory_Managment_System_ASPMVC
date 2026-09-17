using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Models.Enums;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public interface IInventoryTransactionService
    {
        public bool CreateTransaction(InventoryTransaction transaction);
        public InventoryTransaction? GetById(int id);
        public IEnumerable<InventoryTransaction> GetByProductId(int id);
        public IEnumerable<InventoryTransaction> GetByType(InventoryTransactionType type);
        public IEnumerable<InventoryTransaction> GetByDateRange(DateTime from, DateTime to);
        public IEnumerable<InventoryTransaction> GetRecentTransactions(int count);
        public IEnumerable<InventoryTransaction> GetAll();
    }
}
