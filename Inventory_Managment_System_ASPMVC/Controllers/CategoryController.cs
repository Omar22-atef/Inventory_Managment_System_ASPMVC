using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
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
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
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
        public IActionResult Edit(int id)
        {
            Category category = _categoryService.GetById(id);
            if (category == null) return NotFound();
            return View("Edit", category);
        }

        [HttpPost]
        public IActionResult Edit(Category updatedCategory)
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
        public IActionResult Delete(int id)
        {
            var category = _categoryService.GetById(id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            bool success = _categoryService.DeleteCategory(id);

            if (!success)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
