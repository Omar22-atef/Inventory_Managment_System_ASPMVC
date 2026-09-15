using Inventory_Managment_System_ASPMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        { 
            _context = context;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _context.Products.Include(c => c.category).ToList();
        }

        public void Add(Product newProduct)
        { 
            _context.Products.Add(newProduct);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ExistsSKU(string sku)
        {
            
            return _context.Products.IgnoreQueryFilters().Any(p => p.SKU == sku);
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool ExistsBySKUId(string sku, int id)
        {
            return _context.Products.IgnoreQueryFilters().Any(p => p.Id != id && p.SKU == sku);
        }
    }
}
