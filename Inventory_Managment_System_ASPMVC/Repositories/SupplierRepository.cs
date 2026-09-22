using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationContext _context;
        public SupplierRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return _context.Suppliers.ToList();
        }
        public Supplier? GetById(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.Id == id);
        }
        public void Add(Supplier supplier)
        {
            _context.Suppliers.Add(supplier);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public bool ExistsByName(string name)
        { 
            return _context.Suppliers.Any(s => s.Name == name);
        }
        public bool ExistsByNameId(string name, int id)
        {
            return _context.Suppliers.Any(s => s.Name == name && s.Id != id);
        }
        public IEnumerable<Supplier> Search(string keyword)
        {
            return _context.Suppliers.Where(s => s.Name.Contains(keyword) || s.City.Contains(keyword) || s.Address.Contains(keyword)).ToList();
        }

        public IEnumerable<Supplier> GetByCity(string city)
        {
            return _context.Suppliers.Where(s => s.City == city).OrderBy(s => s.Name).ToList();
        }

        public IEnumerable<Supplier> GetSuppliersWithProducts()
        {
            return _context.Suppliers.Where(s => s.ProductSuppliers.Any()).Include(ps => ps.ProductSuppliers).ThenInclude(p => p.Product).ToList();
        }

        public IEnumerable<Supplier> GetSuppliersByProduct(int productId)
        {
            return _context.Suppliers.Where(s => s.ProductSuppliers.Any(p => p.ProductId == productId)).ToList();
        }

        public IEnumerable<SupplierTransactionCountDto> GetSuppliersWithTransactionCount()
        {
            return _context.Suppliers.Select(s => new SupplierTransactionCountDto { SupplierId = s.Id, SupplierName = s.Name, TransactionCount = s.InventoryTransactions.Count()}).ToList();
        }

        public IEnumerable<SupplierTransactionCountDto> GetTopSuppliersByTransactions(int count)
        {
            return _context.Suppliers.Select(s => new SupplierTransactionCountDto 
            { SupplierId = s.Id, SupplierName = s.Name, TransactionCount = s.InventoryTransactions.Count()})
                .OrderByDescending(s => s.TransactionCount).Take(count).ToList();
        }

        public IEnumerable<Supplier> GetSuppliersWithoutTransactions()
        { 
            return _context.Suppliers.Where(s => !s.InventoryTransactions.Any()).ToList();
        }

        public bool HasTransactions(int supplierId)
        {
            return _context.InventoryTransactions.Any(t => t.SupplierId == supplierId);
        }

        public bool SuppliesProduct(int supplierId, int productId)
        {
            return _context.ProductSuppliers
                .Any(ps => ps.SupplierId == supplierId &&
                          ps.ProductId == productId);
        }

    }
}
