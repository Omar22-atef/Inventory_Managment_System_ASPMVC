using Inventory_Managment_System_ASPMVC.Migrations;
using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
        public void Add(Category newCategory);
        public void Save();
        public bool ExistsByName(string name);
        public Category? GetById(int id);
        public bool ExistsByNameId(string name, int id);
    }
}
