using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetAllProducts();
        public void Add(Product newProduct);
        public void Save();
        public bool ExistsSKU(string sku);
        public Product? GetById(int id);
        public bool ExistsBySKUId(string sku, int id);
    }
}
