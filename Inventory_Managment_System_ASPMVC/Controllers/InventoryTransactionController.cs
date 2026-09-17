using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Inventory_Managment_System_ASPMVC.Models.Enums;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    public class InventoryTransactionController : Controller
    {
        private readonly IInventoryTransactionService _inventoryTransactionService;
        private readonly IProductService _productService;
        public InventoryTransactionController(IInventoryTransactionService inventoryTransactionService, IProductService productService)
        { 
            _inventoryTransactionService = inventoryTransactionService;
            _productService = productService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var allTransactions = _inventoryTransactionService.GetAll();
            return View("Index", allTransactions);
        }

        [HttpGet]
        public IActionResult Create()
        { 
            var products = _productService.GetAllProducts();

            var transaction = new InventoryTransactionCreateViewModel
            {
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
            };

            return View("Create", transaction);
        }

        [HttpPost]
        public IActionResult Create(InventoryTransactionCreateViewModel newTransaction)
        {
            
            if (ModelState.IsValid)
            {
                InventoryTransaction transaction = new InventoryTransaction()
                {
                    ProductId = newTransaction.ProductId,
                    Quantity = newTransaction.Quantity,
                    Type = newTransaction.Type,
                };

                bool success = _inventoryTransactionService.CreateTransaction(transaction);
                if (success)
                { 
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Unable to create transaction. Please check the stock quantity.");

            }
            var products = _productService.GetAllProducts();

            var transactions = new InventoryTransactionCreateViewModel
            {
                Products = products.Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
            };

            return View("Create", transactions);
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
