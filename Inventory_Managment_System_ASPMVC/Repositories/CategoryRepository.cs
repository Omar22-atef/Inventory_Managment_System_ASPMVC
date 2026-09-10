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

        public void Add(Category category)
        {
            context.Categories.Add(category);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public bool ExistsByName(string name)
        {
            return context.Categories.Any(c => c.Name == name);
        }

        public Category? GetById(int id)
        {
            return context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool ExistsByNameId(string name, int id)
        {
            return context.Categories.Any(c => c.Name == name && c.Id != id);
        }

        
    }
}
