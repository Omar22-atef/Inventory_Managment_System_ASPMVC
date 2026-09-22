using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Models;

public interface ISupplierRepository
{
    IEnumerable<Supplier> GetAll();
    Supplier? GetById(int id);

    void Add(Supplier supplier);
    void Save();

    bool ExistsByName(string name);
    bool ExistsByNameId(string name, int id);

    IEnumerable<Supplier> Search(string keyword);

    IEnumerable<Supplier> GetByCity(string city);

    IEnumerable<Supplier> GetSuppliersWithProducts();

    IEnumerable<SupplierTransactionCountDto> GetSuppliersWithTransactionCount();

    IEnumerable<SupplierTransactionCountDto> GetTopSuppliersByTransactions(int count);

    IEnumerable<Supplier> GetSuppliersWithoutTransactions();

    IEnumerable<Supplier> GetSuppliersByProduct(int productId);
    bool HasTransactions(int supplierId);
    bool SuppliesProduct(int supplierId, int productId);
}