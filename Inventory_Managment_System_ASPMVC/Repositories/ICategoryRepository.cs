using Inventory_Managment_System_ASPMVC.Models;

namespace Inventory_Managment_System_ASPMVC.Repositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetAllCategories();
    }
}
