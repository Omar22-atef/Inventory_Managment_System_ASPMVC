using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    [Authorize]
    public class SupplierController : Controller
    {
        private readonly ISupplierService _supplierService;
        public SupplierController(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var suppliers = _supplierService.GetAll();
            return View("Index", suppliers);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Create()
        {
            return View("Create");
        }
        
        [HttpPost]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Create(Supplier newSupplier)
        {
            if (ModelState.IsValid)
            {
                bool success = _supplierService.Add(newSupplier);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", "Supplier already exists.");
            }
            return View("Create", newSupplier);
        }
       
        [HttpGet]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Edit(int id)
        {
            var supplier = _supplierService.GetById(id);
            if (supplier == null) return NotFound();
            return View("Edit", supplier);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Edit(Supplier updatedSupplier)
        {
            if (ModelState.IsValid)
            {
                bool success = _supplierService.Update(updatedSupplier);
                if (success)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", "Supplier already exists.");
            }
            return View("Edit", updatedSupplier);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult Delete(int id)
        {
            var supplier = _supplierService.GetById(id);
            if (supplier == null) return NotFound();
            return View("Delete", supplier);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin,InventoryManager")]
        public IActionResult DeleteConfirmed(int id)
        {
            var supplier = _supplierService.GetById(id);

            if (supplier == null)
                return NotFound();

            bool success = _supplierService.Delete(id);

            if (!success)
            {
                TempData["Error"] = "This supplier cannot be deleted because it has transactions.";
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Search(string keyword)
        {
            var suppliers = _supplierService.Search(keyword);
            return View("Index", suppliers);
        }

        [HttpGet]
        public IActionResult GetByCity(string city)
        {
            var supplier = _supplierService.GetByCity(city);
            return View("GetByCity", supplier);
        }
        [HttpGet]
        public IActionResult GetSuppliersWithProducts()
        {
            var suppliers = _supplierService.GetSuppliersWithProducts();
            return View("GetSuppliersWithProducts", suppliers);
        }
        [HttpGet]
        public IActionResult GetSuppliersWithTransactionCount()
        {
            var suppliers = _supplierService.GetSuppliersWithTransactionCount();
            return View("GetSuppliersWithTransactionCount", suppliers);
        }
        [HttpGet]
        public IActionResult GetTopSuppliersByTransactions(int count)
        {
            var suppliers = _supplierService.GetTopSuppliersByTransactions(count);
            return View("GetTopSuppliersByTransactions", suppliers);
        }
        [HttpGet]
        public IActionResult GetSuppliersWithoutTransactions()
        {
            var suppliers = _supplierService.GetSuppliersWithoutTransactions();
            return View("GetSuppliersWithoutTransactions", suppliers);
        }
        [HttpGet]
        public IActionResult GetSuppliersByProduct(int productId)
        { 
            var suppliers = _supplierService.GetSuppliersByProduct(productId);
            return View("GetSuppliersByProduct", suppliers);
        }
    }
}
