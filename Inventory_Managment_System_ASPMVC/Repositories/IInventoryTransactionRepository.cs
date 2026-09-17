using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Models.Enums;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public interface IInventoryTransactionRepository
    {
        void Add(InventoryTransaction transaction);
        void Save();

        IEnumerable<InventoryTransaction> GetAll();
        InventoryTransaction? GetById(int id);

        IEnumerable<InventoryTransaction> GetByProductId(int productId);

        IEnumerable<InventoryTransaction> GetByType(InventoryTransactionType type);

        IEnumerable<InventoryTransaction> GetByDateRange(
            DateTime from,
            DateTime to);

        IEnumerable<InventoryTransaction> GetRecentTransactions(int count);

    }
}
