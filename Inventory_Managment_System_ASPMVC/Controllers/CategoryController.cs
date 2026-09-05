using Inventory_Managment_System_ASPMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inventory_Managment_System_ASPMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationContext context;
        public CategoryController(ApplicationContext context) 
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            return View("Index", categories);
        }
    }
}
