using Inventory_Managment_System_ASPMVC.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public interface ICategoryService
    {
        public List<Category> GetAllCategories();
        public bool CreateCategory(Category newCategory);
        public bool UpdateCategory(Category updatedCategory);
        public Category? GetById(int id);
        public bool DeleteCategory(int id);
    }
}
