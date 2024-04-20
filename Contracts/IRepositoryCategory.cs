
using Entities.Models;

namespace Contracts
{
    public interface IRepositoryCategory
    {
        IEnumerable<Category> getAllCategories(bool trackChange);

        Category? getCategory(int id, bool trackChange);

        void createCategory(Category category);

        void updateCategory(Category category);

        void deleteCategory(Category category);

    }
}
