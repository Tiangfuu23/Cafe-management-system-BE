
using Entities.Models;

namespace Contracts
{
    public interface IRepositoryCategory
    {
        IEnumerable<Category> GetAllCategories(bool trackChange);

        Category? GetCategory(int id, bool trackChange);

        void CreateCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);

    }
}
