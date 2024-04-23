using Contracts;
using Entities.Models;

namespace Repository
{
    internal class RepositoryCategory : RepositoryBase<Category> ,IRepositoryCategory
    {
        public RepositoryCategory(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            
        }
        public IEnumerable<Category> GetAllCategories(bool trackChange)
        {
            return FindAll(trackChange).OrderBy(c => c.id).ToList();
        }

        public Category? GetCategory(int id, bool trackChange)
        {
            return FindByCondition(c => c.id == id, trackChange).SingleOrDefault();
        }

        public void CreateCategory(Category category)
        {
            Create(category);
        }

        public void DeleteCategory(Category category)
        {
            Delete(category);
        }


        public void UpdateCategory(Category category)
        {
            Update(category);
        }
    }
}
