using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryService _categoryService;
        public CategoryController(CategoryService categoryService) 
        {
            _categoryService = categoryService;
        }
        public IActionResult Index()
        {
            var categories = _categoryService.GetAllCategories();
            return View("Index", categories);
        }

        //private bool CategoryNameExists(string name, int id)
        //{
        //    return context.Categories.Any(c => c.Name.ToLower() == name.Trim().ToLower() && c.Id != id);
        //}

        //[HttpGet]
        //public IActionResult Create()
        //{ 
        //    return View("Create");
        //}

        //[HttpPost]
        //public IActionResult Create(Category newCategory)
        //{
        //    newCategory.Name = newCategory.Name.Trim();
        //    if (ModelState.IsValid)
        //    {
        //        if (!CategoryNameExists(newCategory.Name, newCategory.Id))
        //        {
        //            context.Categories.Add(newCategory);
        //            context.SaveChanges();
        //            return RedirectToAction("Index");
        //        }
        //        ModelState.AddModelError("Name", "Category name must be unique.");
        //    }
        //    return View("Create", newCategory);
        //}
    }
}
