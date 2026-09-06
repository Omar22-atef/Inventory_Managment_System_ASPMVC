using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext context;

        public CategoryRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public List<Category> GetAllCategories()
        {
            return context.Categories.ToList();
        }
    }
}
