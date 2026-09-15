using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Repositories;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        { 
            return _productRepository.GetAllProducts();
        }

        private string Normalize(string sku)
        {
            return sku.ToLower().Trim();
        }
        public bool CreateProduct(Product newProduct)
        {
            newProduct.SKU = Normalize(newProduct.SKU);

            var category = _categoryRepository.GetById(newProduct.CategoryId);

            if (category == null)
            {
                return false;
            }

            if (!_productRepository.ExistsSKU(newProduct.SKU))
            { 
                _productRepository.Add(newProduct);
                _productRepository.Save();
                return true;
            }
            return false;
        }

        public Product? GetById(int id)
        { 
            return _productRepository.GetById(id);
        }

        public bool UpdatedProduct(Product updatedProduct)
        { 
            updatedProduct.SKU = Normalize(updatedProduct.SKU);
            var existingProduct = GetById(updatedProduct.Id);

            var category = _categoryRepository.GetById(updatedProduct.CategoryId);

            if (existingProduct == null)
                return false;

            if (category == null)
            {
                return false;
            }

            if (_productRepository.ExistsBySKUId(updatedProduct.SKU, updatedProduct.Id))
            {
                return false;
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Description = updatedProduct.Description;
            existingProduct.PurchasePrice = updatedProduct.PurchasePrice;
            existingProduct.SellingPrice = updatedProduct.SellingPrice;
            existingProduct.CurrentStock = updatedProduct.CurrentStock;
            existingProduct.MinimumStock = updatedProduct.MinimumStock;
            existingProduct.CategoryId = updatedProduct.CategoryId;
            existingProduct.SKU = updatedProduct.SKU;
            _productRepository.Save();
            return true;
        }

        public bool DeleteProduct(int id)
        { 
            var deletedProduct = GetById(id);
            if (deletedProduct == null) return false;
            deletedProduct.IsDeleted = true;
            _productRepository.Save();
            return true;
        }


    }
}
