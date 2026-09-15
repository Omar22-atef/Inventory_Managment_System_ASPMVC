using System.Security.Cryptography;
using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts(); 
        public bool CreateProduct(Product newProduct);
        public Product? GetById(int id);
        public bool UpdatedProduct(Product updatedProduct);
        public bool DeleteProduct(int id);
    }
}
