using Inventory_Managment_System_ASPMVC.Models;
using Inventory_Managment_System_ASPMVC.Repositories;

namespace Inventory_Managment_System_ASPMVC.Services
{
    public class CategoryService: ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public List<Category> GetAllCategories()
        {
            return categoryRepository.GetAllCategories();
        }
    }
}
