using Inventory_Managment_System_ASPMVC.DTOs;
using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Repositories;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public IEnumerable<Supplier> GetAll()
        { 
            return _supplierRepository.GetAll();
        }
        public Supplier? GetById(int id)
        { 
            return _supplierRepository.GetById(id);
        }

        private string Normalize(string name)
        {
            return name.ToLower().Trim();
        }
        public bool Add(Supplier newSupplier)
        { 
            newSupplier.Name = Normalize(newSupplier.Name);
            if (!_supplierRepository.ExistsByName(newSupplier.Name))
            { 
                _supplierRepository.Add(newSupplier);
                _supplierRepository.Save();
                return true;
            }
            return false;
        
        }
        public bool Update(Supplier updatedSupplier)
        { 
            updatedSupplier.Name = Normalize(updatedSupplier.Name);
            var existingSupplier = GetById(updatedSupplier.Id);
            
            if (existingSupplier == null) return false;
            if(_supplierRepository.ExistsByNameId(updatedSupplier.Name, updatedSupplier.Id)) return false;

            existingSupplier.Name = updatedSupplier.Name;
            existingSupplier.City = updatedSupplier.City;
            existingSupplier.Address = updatedSupplier.Address;
            _supplierRepository.Save();
            return true;
        }
        public bool Delete(int id)
        { 
            var supplier = _supplierRepository.GetById(id);
            if (supplier == null) return false;
            if(_supplierRepository.HasTransactions(id)) return false;
            supplier.IsDeleted = true;
            _supplierRepository.Save();
            return true;
        }
        public IEnumerable<Supplier> Search(string keyword)
        { 
            keyword = Normalize(keyword);
            return _supplierRepository.Search(keyword);
        }
        public IEnumerable<Supplier> GetByCity(string city)
        { 
            return _supplierRepository.GetByCity(city);
        }
        public IEnumerable<Supplier> GetSuppliersWithProducts()
        { 
            return _supplierRepository.GetSuppliersWithProducts();
        }
        public IEnumerable<SupplierTransactionCountDto> GetSuppliersWithTransactionCount()
        {
            return _supplierRepository.GetSuppliersWithTransactionCount();
        }
        public IEnumerable<SupplierTransactionCountDto> GetTopSuppliersByTransactions(int count)
        {
            return _supplierRepository.GetTopSuppliersByTransactions(count);
        }
        public IEnumerable<Supplier> GetSuppliersWithoutTransactions()
        {
            return _supplierRepository.GetSuppliersWithoutTransactions();
        }
        public IEnumerable<Supplier> GetSuppliersByProduct(int productId)
        {
            return _supplierRepository.GetSuppliersByProduct(productId);
        }
    }
}
