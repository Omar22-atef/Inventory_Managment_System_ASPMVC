using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public List<Category> GetAllCategories()
        {
            return _context.Categories.ToList();
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool ExistsByName(string name)
        {
            return _context.Categories.Any(c => c.Name == name);
        }

        public Category? GetById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public bool ExistsByNameId(string name, int id)
        {
            return _context.Categories.Any(c => c.Name == name && c.Id != id);
        }

        
    }
}
