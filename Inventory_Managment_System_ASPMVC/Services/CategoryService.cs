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

        private string Normalize(string name)
        {
            return name.Trim().ToLower();
        }

        public bool CreateCategory(Category newCategory)
        {
            newCategory.Name = Normalize(newCategory.Name);
            if (!categoryRepository.ExistsByName(newCategory.Name))
            { 
                categoryRepository.Add(newCategory);
                categoryRepository.Save();
                return true;
            }
            return false;
        }

        public bool UpdateCategory(Category updatedCategory)
        {
            updatedCategory.Name = Normalize(updatedCategory.Name);
            var existedCategory = categoryRepository.GetById(updatedCategory.Id);

            if (existedCategory == null)
            {
                return false;
            }

            if (categoryRepository.ExistsByNameId(updatedCategory.Name, updatedCategory.Id))
            {
                return false;
            }

            existedCategory.Name = updatedCategory.Name;
            existedCategory.Description = updatedCategory.Description;
            categoryRepository.Save();
            return true;
        }

        public Category? GetById(int id)
        { 
            return categoryRepository.GetById(id);
        }

        public bool DeleteCategory(int id)
        { 
            Category category = categoryRepository.GetById(id);
            if (category == null)
            {
                return false;
            }
            category.IsDeleted = true;
            categoryRepository.Save();
            return true;
        }
    }
}
