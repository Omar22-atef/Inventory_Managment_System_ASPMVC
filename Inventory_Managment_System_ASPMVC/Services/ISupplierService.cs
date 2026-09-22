using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public interface ISupplierService
    {
        public IEnumerable<Supplier> GetAll();
        public Supplier? GetById(int id);
        public bool Add(Supplier newSupplier);
        public bool Update(Supplier updatedSupplier);
        public bool Delete(int id);
        public IEnumerable<Supplier> Search(string keyword);
        public IEnumerable<Supplier> GetByCity(string city);
        public IEnumerable<Supplier> GetSuppliersWithProducts();    
        public IEnumerable<SupplierTransactionCountDto> GetSuppliersWithTransactionCount();
        public IEnumerable<SupplierTransactionCountDto> GetTopSuppliersByTransactions(int count);
        public IEnumerable<Supplier> GetSuppliersWithoutTransactions();
        public IEnumerable<Supplier> GetSuppliersByProduct(int productId);
    }
}
