using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Inventory_Managment_System_ASPMVC.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View("Index", categories);
        }


        [HttpGet]
        [Authorize(Roles = "SuperAdmin, InventoryManager")]

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, InventoryManager")]

        public IActionResult Create(CreateCategoryViewModel newCategory)
        {

            if (ModelState.IsValid)
            {
                bool success = _categoryService.CreateCategory(newCategory);
                if (success)
                { 
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", "Category already exists.");
            }
            return View("Create");
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, InventoryManager")]
        public IActionResult Edit(int id)
        {
            Category category = _categoryService.GetById(id);
            if (category == null) return NotFound();
            var updatedCategory = new CreateCategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
            return View("Edit", updatedCategory);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, InventoryManager")]

        public IActionResult Edit(CreateCategoryViewModel updatedCategory)
        {
            if (ModelState.IsValid)
            { 
                bool success = _categoryService.UpdateCategory(updatedCategory);
                if (success)
                { 
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("Name", "Category already exists.");
            }

            return View("Edit", updatedCategory);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, InventoryManager")]

        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, InventoryManager")]

        public IActionResult DeleteCategory(int id)
        {
            bool success = _categoryService.DeleteCategory(id);

            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
