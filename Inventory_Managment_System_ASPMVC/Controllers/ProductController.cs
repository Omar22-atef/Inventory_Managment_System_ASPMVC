using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ISupplierService _supplierService;
        public ProductController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _supplierService = supplierService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allProducts = _productService.GetAllProducts();

            var viewModels = new List<ProductCategoryViewModel>();

            foreach (var product in allProducts)
            {
                var viewModel = new ProductCategoryViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    SKU = product.SKU,
                    Description = product.Description,
                    PurchasePrice = product.PurchasePrice,
                    SellingPrice = product.SellingPrice,
                    CurrentStock = product.CurrentStock,
                    MinimumStock = product.MinimumStock,
                    CategoryName = product.category.Name
                };

                viewModels.Add(viewModel);
            }

            return View("Index", viewModels);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var categories = _categoryService.GetAllCategories();
            var suppliers = _supplierService.GetAll();

            var product = new ProductCreateViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }),
                Suppliers = suppliers.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
            };

            return View("Create", product);
        }
        [HttpPost]
        public IActionResult Create(ProductCreateViewModel newProduct)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Name = newProduct.Name,
                    Description = newProduct.Description,
                    SKU = newProduct.SKU,
                    PurchasePrice = newProduct.PurchasePrice,
                    SellingPrice = newProduct.SellingPrice,
                    MinimumStock = newProduct.MinimumStock,
                    CategoryId = newProduct.CategoryId,
                    ProductSuppliers = newProduct.SupplierIds?.Select(supplierId => new ProductSuppliers
                    {
                        SupplierId = supplierId
                    }).ToList() ?? new List<ProductSuppliers>()
                };

                bool success = _productService.CreateProduct(product);

                if (success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError("SKU", "SKU Already Exists");
            }

            var categories = _categoryService.GetAllCategories();
            var suppliers = _supplierService.GetAll();

            newProduct.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            newProduct.Suppliers = suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            return View("Create", newProduct);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            var categories = _categoryService.GetAllCategories();
            var suppliers = _supplierService.GetAll();
            var productViewModel = new ProductCreateViewModel
            {
                Categories = categories.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }),

                Suppliers = suppliers.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                }),

                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                SKU = product.SKU,
                PurchasePrice = product.PurchasePrice,
                SellingPrice = product.SellingPrice,
                MinimumStock = product.MinimumStock,
                CategoryId = product.CategoryId,

                SupplierIds = product.ProductSuppliers
                .Select(ps => ps.SupplierId)
                .ToList()
            };
            return View("Edit", productViewModel);
        }

        [HttpPost]
        public IActionResult Edit(ProductCreateViewModel updatedProduct)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Id = updatedProduct.Id,
                    Name = updatedProduct.Name,
                    Description = updatedProduct.Description,
                    SKU = updatedProduct.SKU,
                    PurchasePrice = updatedProduct.PurchasePrice,
                    SellingPrice = updatedProduct.SellingPrice,
                    MinimumStock = updatedProduct.MinimumStock,
                    CategoryId = updatedProduct.CategoryId,
                    ProductSuppliers = updatedProduct.SupplierIds
                   .Select(supplierId => new ProductSuppliers {SupplierId = supplierId}).ToList()
                };
                bool success = _productService.UpdatedProduct(product);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("SKU", "SKU Already Exists");
                }
            }

            var categories = _categoryService.GetAllCategories();
            var suppliers = _supplierService.GetAll();
            updatedProduct.Categories = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });

            updatedProduct.Suppliers = suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            return View("Edit", updatedProduct);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        { 
            var product = _productService.GetById(id);
            if (product == null) return NotFound();
            return View("Delete", product);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            bool success = _productService.DeleteProduct(id);
            if (success)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return NotFound();
            }
        }

    }
}
