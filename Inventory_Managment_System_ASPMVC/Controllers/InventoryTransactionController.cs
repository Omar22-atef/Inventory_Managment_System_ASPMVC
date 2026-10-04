using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Inventory_Managment_System_ASPMVC.Models.Enums;
using Microsoft.AspNetCore.Authorization;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    [Authorize]
    public class InventoryTransactionController : Controller
    {
        private readonly IInventoryTransactionService _inventoryTransactionService;
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        public InventoryTransactionController(IInventoryTransactionService inventoryTransactionService, IProductService productService, ISupplierService supplierService)
        {
            _inventoryTransactionService = inventoryTransactionService;
            _productService = productService;
            _supplierService = supplierService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allTransactions = _inventoryTransactionService.GetAll();
            return View("Index", allTransactions);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Create()
        { 
            var products = _productService.GetAllProducts();
            var suppliers = _supplierService.GetAll();

            var transaction = new InventoryTransactionCreateViewModel
            {
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                }),
                Suppliers = suppliers.Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.Name
                })
            };

            return View("Create", transaction);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Create(InventoryTransactionCreateViewModel newTransaction)
        {
            if (ModelState.IsValid)
            {
                InventoryTransaction transaction = new InventoryTransaction()
                {
                    ProductId = newTransaction.ProductId,
                    Quantity = newTransaction.Quantity,
                    Type = newTransaction.Type,
                    SupplierId = newTransaction.SupplierId,
                };

                bool success = _inventoryTransactionService.CreateTransaction(transaction);

                if (success)
                {
                    return RedirectToAction("Index");
                }

                ModelState.AddModelError(
                    "",
                    "Unable to create transaction. Please check the stock quantity."
                );
            }

            var products = _productService.GetAllProducts();
            var suppliers = _supplierService.GetAll();

            newTransaction.Products = products.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Name
            });

            newTransaction.Suppliers = suppliers.Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Name
            });

            return View("Create", newTransaction);
        }

        [HttpGet]
        public IActionResult GetById(int id)
        {
            var transaction = _inventoryTransactionService.GetById(id);
            if (transaction == null) return NotFound();
            return View("GetById", transaction);
        }

        [HttpGet]
        public IActionResult GetByType(InventoryTransactionType type)
        { 
            var transaction = _inventoryTransactionService.GetByType(type);
            return View("GetByType", transaction);
        }

        [HttpGet]
        public IActionResult GetRecentTransactions(int count)
        { 
            var transactions = _inventoryTransactionService.GetRecentTransactions(count);
            return View("GetRecentTransactions", transactions);
        }

        [HttpGet]
        public IActionResult GetByProductId(int id)
        { 
            var transactions = _inventoryTransactionService.GetByProductId(id);
            return View("GetByProductId", transactions);
        }

        [HttpGet]
        public IActionResult GetByDate(DateTime from, DateTime to)
        { 
            var transactions = _inventoryTransactionService.GetByDateRange(from, to);
            return View("GetByDate", transactions);
        }

    }
}
