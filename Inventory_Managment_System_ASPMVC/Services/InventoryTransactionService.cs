using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Models.Enums;
using Inventory_Managment_System_ASPMVC.Repositories;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public class InventoryTransactionService : IInventoryTransactionService
    {
        private readonly IInventoryTransactionRepository _inventoryTransactionRepository;
        private readonly IProductRepository _productRepository;

        public InventoryTransactionService(IInventoryTransactionRepository inventoryTransactionRepository, IProductRepository productRepository)
        {
            _inventoryTransactionRepository = inventoryTransactionRepository;
            _productRepository = productRepository;
        }

        public bool CreateTransaction(InventoryTransaction transaction)
        {
            var product = _productRepository.GetById(transaction.ProductId);

            if (product == null)
                return false;

            if (transaction.Quantity <= 0)
                return false;

            if (transaction.Type == InventoryTransactionType.Purchase ||
                transaction.Type == InventoryTransactionType.Return ||
                transaction.Type == InventoryTransactionType.AdjustmentIncrease)
            {
                product.CurrentStock += transaction.Quantity;
            }

            else if (transaction.Type == InventoryTransactionType.Sale ||
                     transaction.Type == InventoryTransactionType.AdjustmentDecrease)
            {
                if (transaction.Quantity > product.CurrentStock)
                    return false;

                product.CurrentStock -= transaction.Quantity;
            }

            _inventoryTransactionRepository.Add(transaction);

            _inventoryTransactionRepository.Save();

            return true;
        }

        public InventoryTransaction? GetById(int id)
        { 
            return _inventoryTransactionRepository.GetById(id);
        }

        public IEnumerable<InventoryTransaction> GetByProductId(int id)
        {
            return _inventoryTransactionRepository.GetByProductId(id);
        }

        public IEnumerable<InventoryTransaction> GetByType(InventoryTransactionType type)
        { 
            return _inventoryTransactionRepository.GetByType(type);
        }

        public IEnumerable<InventoryTransaction> GetByDateRange(DateTime from, DateTime to)
        {
            if (from > to)
                return Enumerable.Empty<InventoryTransaction>();

            var endDate = to.Date.AddDays(1);

            return _inventoryTransactionRepository.GetByDateRange(from.Date, endDate);
        }

        public IEnumerable<InventoryTransaction> GetRecentTransactions(int count)
        {
            if(count < 0)
                return Enumerable.Empty<InventoryTransaction>();
            return _inventoryTransactionRepository.GetRecentTransactions(count);
        }

        public IEnumerable<InventoryTransaction> GetAll()
        {
            return _inventoryTransactionRepository.GetAll();
        }
    }
}
