using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryCategory : RepositoryBase<Category> ,IRepositoryCategory
    {
        public RepositoryCategory(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public IEnumerable<Category> getAllCategories(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(c => c.id).ToList();
        }

        public Category? getCategory(int id, bool trackChange)
        {
            return FindByCondition(c => c.id == id, trackChange).SingleOrDefault();
        }

        public void createCategory(Category category)
        {
            Create(category);
        }

        public void deleteCategory(Category category)
        {
            Delete(category);
        }


        public void updateCategory(Category category)
        {
            Update(category);
        }
    }
}
